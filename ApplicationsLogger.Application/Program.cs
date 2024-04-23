using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AtlasStarter
{
    class MongoDBContext
    {
        static void Main(string[] args)
        {
            var mongoUri = "mongodb+srv://JoaoHong:JoaoHong%40IU360@modelologger.uqep7gr.mongodb.net/?retryWrites=true&w=majority&appName=ModeloLogger";
            IMongoClient client = null;

            try
            {
                client = new MongoClient(mongoUri);

                // Testar a conexão
                var database = client.GetDatabase("sample_mflix"); 

                // Selecionar uma coleção para consulta
                var collection = database.GetCollection<BsonDocument>("movies");

                // Consulta simples para encontrar todos os documentos na coleção
                var documents = collection.Find(new BsonDocument()).ToList();

                Console.WriteLine("Conexão bem-sucedida com MongoDB Atlas!");
                Console.WriteLine($"Número de documentos na coleção: {documents.Count}");

                // Exemplo de impressão dos documentos
                foreach (var document in documents)
                {
                    Console.WriteLine(document.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Houve um problema ao conectar ao seu cluster MongoDB Atlas. " +
                    $"Verifique a string de conexão e a configuração do cluster. Mensagem de erro: {e.Message}");
                Console.WriteLine(e);
            }
        }
    }
}
