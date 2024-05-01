using TechTest2024;

var builder = WebApplication.CreateSlimBuilder(args);
builder.Services.AddTransient<IIterativeStringConcatenationService, IterativeStringConcatenationService>();

var app = builder.Build();

var converter = app.Services.GetService<IIterativeStringConcatenationService>();

var numericConverterApi = app.MapGroup("/convertnumeric");
numericConverterApi.MapGet("/{input}", (string input) =>
{
	return converter.ToWords(input);
});

app.Run();