using AgriIntel_Advisory_System.Data;
using AgriIntel_Advisory_System.Interface;
using AgriIntel_Advisory_System.Repository;
using AgriIntel_Advisory_System.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using AgriIntel_Advisory_System.Middleware;
using System.Text;
using static AgriIntel_Advisory_System.Data.AppDbContext;

var builder = WebApplication.CreateBuilder(args);

// ---------------- REPOSITORIES ----------------
builder.Services.AddScoped<FarmerInterface, FarmerRepository>();
builder.Services.AddScoped<StaffInterface, StaffRepository>();
builder.Services.AddScoped<ExpertInterface, ExpertRepository>();
builder.Services.AddScoped<ArticleInterface, ArticleRepository>();
builder.Services.AddScoped<RegisterInterface, RegisterRepository>();
builder.Services.AddScoped<LoginInterface, LoginRepository>();
builder.Services.AddScoped<KisanKendraInterface, KKRepository>();
builder.Services.AddScoped<AdminInterface, AdminRepository>();

// ---------------- API SERVICES ----------------
builder.Services.AddScoped<FarmerApiService>();
builder.Services.AddScoped<StaffApiService>();
builder.Services.AddScoped<ExpertApiService>();
builder.Services.AddScoped<ArticleApiService>();
builder.Services.AddScoped<RegisterApiService>();
builder.Services.AddScoped<LoginApiService>();
builder.Services.AddScoped<KKApiService>();
builder.Services.AddScoped<AdminApiService>();



// ---------------- API SETTINGS + HTTP CLIENT ----------------
builder.Services.Configure<Apisettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddHttpClient("MyApi", (sp, client) =>
{
    var settings = sp.GetRequiredService<IOptions<Apisettings>>().Value;
    client.BaseAddress = new Uri(settings.BaseUrl);
})
.ConfigurePrimaryHttpMessageHandler(() =>
{
    return new HttpClientHandler
    {
        AllowAutoRedirect = true,
        ServerCertificateCustomValidationCallback =
            HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    };
});

// 🔴 ADD THIS for Login Page HttpClient
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("http://localhost:5129");
});

// ---------------- MVC + RAZOR ----------------
builder.Services.AddControllers();

builder.Services.AddRazorPages();

builder.Services.AddDistributedMemoryCache();
// 🔴 ADD SESSION
builder.Services.AddSession();

// ---------------- DATABASE ----------------
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

// ---------------- JWT AUTHENTICATION ----------------
var jwtKey = builder.Configuration["JWT:Key"];

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey =
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey!))
    };
});

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

// ---------------- SWAGGER ----------------
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer",
        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "JWT",
            In = Microsoft.OpenApi.Models.ParameterLocation.Header,
            Description = "Enter: Bearer {your token}"
        });

    options.AddSecurityRequirement(
        new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
        {
            {
                new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Reference = new Microsoft.OpenApi.Models.OpenApiReference
                    {
                        Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
            }
        });
});

var app = builder.Build();

// ---------------- PIPELINE ----------------
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseMiddleware<AdminAuthMiddleware>();
app.UseMiddleware<RoleAuthMiddleware>(); 
app.UseAuthentication();  
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();