


Console.WriteLine("Iniciando execução.");
Task<int> asyncResult = TarefaAssincrona();

Console.WriteLine("Aguardando o término do método assíncrono.");
do
{
    Console.Write(".");
} while (!asyncResult.IsCompleted);

Console.WriteLine("Console base thread ID: {0}", Thread.CurrentThread.ManagedThreadId);

Console.Read();


static async Task<int> TarefaAssincrona() // https://ferhenriquef.com/2014/03/22/async-methods-e-sua-comparao-com-tasks/
{
    HttpClient client = new HttpClient();

    Console.WriteLine("Executando síncronamente.");

    string urlContents = await client.GetStringAsync("http://www.google.com");

    Console.WriteLine("Fim da tarefa assíncrona.");

    Console.WriteLine("Async thread ID: {0}", Thread.CurrentThread.ManagedThreadId);

    return urlContents.Length;
}
