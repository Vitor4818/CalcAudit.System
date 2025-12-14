using CalcAudit.System.Components;
using CalcAudit.System.Services; // <--- ESTE USING É OBRIGATÓRIO

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ?????? A LINHA QUE ESTÁ FALTANDO É ESSA AQUI ??????
builder.Services.AddHttpClient<ICalculoService, CalculoService>();
// ?????? ADICIONE ANTES DO "builder.Build()" ??????

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();