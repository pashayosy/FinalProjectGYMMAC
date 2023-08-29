using FinalProjectGYM.Models.ClientModel;
using FinalProjectGYM.Models.TrainerModel;
using Newtonsoft.Json;
using System;

public static class FileHandle
{
    const string CLIENTFOLDER = "Clients"; 
    const string TRAINERFOLDER = "Coach";

    const string CLIENTFILENAME = "Data.txt";
    const string TRAINERFILENAME = "Data.txt";
    public static void ClientAdd(Client client)//add client to the folder data base
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, client.Id);

        TryToCreateFolder(clientFolderPath);
        string ClientFilePath = Path.Combine(clientFolderPath, CLIENTFILENAME);
        string json = JsonConvert.SerializeObject(client);
        File.WriteAllText(ClientFilePath, json);
    }

    private static void TryToCreateFolder(string folderPathToCheck)//check if the folder exist
    {
        if (!Directory.Exists(folderPathToCheck))
        {
            Directory.CreateDirectory(folderPathToCheck);
        }
    }

    public static void ClientRemove(string id)//set the activ of the client to false
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);
        if (Directory.Exists(clientFolderPath))
        {
            string ClientFilePath = Path.Combine(clientFolderPath, CLIENTFILENAME);
            string json = File.ReadAllText(ClientFilePath);
            Client client = JsonConvert.DeserializeObject<Client>(json);
            client.IsActive = false;
            ClientAdd(client);
        }
    }

    public static Client[] ClientListCreate()//create list of client modify it(remove all inActive clients) and return the active
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER);
        if (Directory.Exists(clientFolderPath))
        {
            string[] allClientPatchs = Directory.GetDirectories(clientFolderPath);
            Client[] clients = new Client[allClientPatchs.Length];

            for (int i = 0; i < allClientPatchs.Length; i++)
            {
                string[] files = Directory.GetFiles(allClientPatchs[i]);
                string json = File.ReadAllText(files[0]);
                Client client = JsonConvert.DeserializeObject<Client>(json);
                clients[i] = client;
            }

            return DeleteNonActiveClients(clients);
        }
        return null;
    }

    private static Client[] DeleteNonActiveClients(Client[]clients)//remove all inActive clients
    {
        int sizeOfActiveClients = 0;

        foreach (Client client in clients)
        {
            sizeOfActiveClients += client.IsActive ? 1 : 0;
        }

        Client[] activeClient = new Client[sizeOfActiveClients];
        int index = 0;

        for(int i = 0; i < clients.Length; i++)
        {
            if (clients[i].IsActive)
            {
                activeClient[index] = clients[i];
                index++;
            }
        }

        return activeClient;
    }

    public static bool IsClientExist(string id)
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);

        return Directory.Exists(clientFolderPath);
    }

    public static void ClientUpdateIdChanged(Client client, string id)
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);
        DeleteDirectory(clientFolderPath);
        ClientAdd(client);
    }

    public static Client GetClientById(string id)
    {
        string clientFolderPath = Path.Combine(CLIENTFOLDER, id);
        string ClientFilePath = Path.Combine(clientFolderPath, CLIENTFILENAME);
        string json = File.ReadAllText(ClientFilePath);
        Client client = JsonConvert.DeserializeObject<Client>(json);

        return client;
    }

    public static void TrainerAdd(Trainer trainer)//add Trainer to the folder data base
    {
        string trainerFolderPath = Path.Combine(TRAINERFOLDER, trainer.Id);

        TryToCreateFolder(trainerFolderPath);
        string trainerFilePath = Path.Combine(trainerFolderPath, TRAINERFILENAME);
        string json = JsonConvert.SerializeObject(trainer);
        File.WriteAllText(trainerFilePath, json);
    }

    public static void TrainerRemove(string id)//set the active of the trainer to false
    {
        string trainerFolderPath = Path.Combine(TRAINERFOLDER, id);
        if (Directory.Exists(trainerFolderPath))
        {
            string trainerFilePath = Path.Combine(trainerFolderPath, TRAINERFILENAME);
            string json = File.ReadAllText(trainerFilePath);
            Trainer trainer = JsonConvert.DeserializeObject<Trainer>(json);
            trainer.IsActive = false;
            TrainerAdd(trainer);
        }
    }

    public static Trainer[] TrainerListCreate()//create list of client modify it(remove all inActive clients) and return the active
    {
        string trainerFolderPath = Path.Combine(TRAINERFOLDER);
        if (Directory.Exists(trainerFolderPath))
        {
            string[] allTrainerPatchs = Directory.GetDirectories(trainerFolderPath);
            Trainer[] trainers = new Trainer[allTrainerPatchs.Length];

            for (int i = 0; i < allTrainerPatchs.Length; i++)
            {
                string[] files = Directory.GetFiles(allTrainerPatchs[i]);
                string json = File.ReadAllText(files[0]);
                Trainer trainer = JsonConvert.DeserializeObject<Trainer>(json);
                trainers[i] = trainer;
            }

            return DeleteNonActiveTrainers(trainers);
        }
        return null;
    }

    private static Trainer[] DeleteNonActiveTrainers(Trainer[] trainers)//remove all inActive clients
    {
        int sizeOfActiveTrainers = 0;

        foreach (Trainer trainer in trainers)
        {
            sizeOfActiveTrainers += trainer.IsActive ? 1 : 0;
        }

        Trainer[] activeTrainers = new Trainer[sizeOfActiveTrainers];
        int index = 0;

        for (int i = 0; i < trainers.Length; i++)
        {
            if (trainers[i].IsActive)
            {
                activeTrainers[index] = trainers[i];
                index++;
            }
        }

        return activeTrainers;
    }

    public static bool IsTrainerExist(string id)
    {
        string trainerFolderPath = Path.Combine(TRAINERFOLDER, id);

        return Directory.Exists(trainerFolderPath);
    }

    public static void TrainerUpdateIdChanged(Trainer trainer, string id)
    {
        string trainerFolderPath = Path.Combine(TRAINERFOLDER, id);
        DeleteDirectory(trainerFolderPath);
        TrainerAdd(trainer);
    }

    public static Trainer GetTrainerById(string id)
    {
        string trainerFolderPath = Path.Combine(TRAINERFOLDER, id);
        string trainerFilePath = Path.Combine(trainerFolderPath, TRAINERFILENAME);
        string json = File.ReadAllText(trainerFilePath);
        Trainer trainer = JsonConvert.DeserializeObject<Trainer>(json);

        return trainer;
    }

    public static void DeleteDirectory(string directoryToDelete) 
    {
        string[] allDirectory = Directory.GetDirectories(directoryToDelete);
        foreach (string directory in allDirectory) 
        {
            DeleteDirectory(directory);
        }

        string[] allDirectoryFile = Directory.GetFiles(directoryToDelete);

        foreach (string  file in allDirectoryFile) 
        {
            File.Delete(file);
        }

        Directory.Delete(directoryToDelete);
    }
}
