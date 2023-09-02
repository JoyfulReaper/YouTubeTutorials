var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/webhook", async context => {
    if (!context.Request.Headers.ContainsKey("Authorization"))
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return;
    }

    var apiKey = context.Request.Headers["Authorization"];
    if(apiKey != "APIKEY")
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return;
    }

    var requestBody = await context.Request.ReadFromJsonAsync<WebhookPayload>();
    await Console.Out.WriteLineAsync($"Header: {requestBody.header}, Body: {requestBody.body}");
    context.Response.StatusCode = StatusCodes.Status200OK;
    await context.Response.WriteAsync("Webhook Ack!");
});

app.Run();

public record WebhookPayload (String header, String body);