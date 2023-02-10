using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddLogging(loggingBuilder => {
    //loggingBuilder.AddFile("D:\\LogText.txt", append: false);


    //var loggingSection = builder.Configuration.GetSection("Logging");
    //loggingBuilder.AddFile(loggingSection);



    //loggingBuilder.AddFile("D:\\app_{0:yyyy}-{0:MM}-{0:dd}.txt", fileLoggerOpts =>
    //{
    //    fileLoggerOpts.FormatLogFileName = fName =>
    //    {
    //        return String.Format(fName, DateTime.UtcNow);
    //    };
    //    fileLoggerOpts.Append = true;
    //    fileLoggerOpts.FileSizeLimitBytes = 1024;
    //    fileLoggerOpts.MaxRollingFiles = 2;
    //    fileLoggerOpts.MinLevel = LogLevel.Warning;
    //});

    //loggingBuilder.AddFile("D:\\logsJson/app.json", fileLoggerOpts =>
    //{
    //    fileLoggerOpts.FormatLogEntry = (msg) =>
    //    {
    //        var sb = new System.Text.StringBuilder();
    //        StringWriter sw = new StringWriter(sb);
    //        var jsonWriter = new Newtonsoft.Json.JsonTextWriter(sw);
    //        jsonWriter.WriteStartArray();
    //        jsonWriter.WriteValue(DateTime.Now.ToString("o"));
    //        jsonWriter.WriteValue(msg.LogLevel.ToString());
    //        jsonWriter.WriteValue(msg.LogName);
    //        jsonWriter.WriteValue(msg.EventId.Id);
    //        jsonWriter.WriteValue(msg.Message);
    //        jsonWriter.WriteValue(msg.Exception?.ToString());
    //        jsonWriter.WriteEndArray();
    //        return sb.ToString();
    //    };
    //});

    //loggingBuilder.AddFile("D:\\logs/errors_only.log", fileLoggerOpts =>
    //{
    //    fileLoggerOpts.FilterLogEntry = (msg) =>
    //    {
    //        return msg.LogLevel == LogLevel.Error;
    //    };
    //});

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
