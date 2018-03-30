using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var pets = new List<Pet>();
        var clinics = new List<Clinic>();

        for (int i = 0; i < n; i++)
        {
            try
            {
                ParseCommand(pets, clinics);
            }
            catch (Exception)
            {
                Console.WriteLine("Invalid Operation!");
            }
        }
    }

    private static void ParseCommand(List<Pet> pets, List<Clinic> clinics)
    {
        var inputArgs = Console.ReadLine()
                        .Split();

        var cmdType = inputArgs[0];

        switch (cmdType)
        {
            case "Create":
                CreateElement(pets, clinics, inputArgs);
                break;
            case "Add":
                AddPetToClinic(pets, clinics, inputArgs);
                break;
            case "Release":
                ReleasePetFromClinic(clinics, inputArgs);
                break;
            case "HasEmptyRooms":
                CheckForEmptyRooms(clinics, inputArgs);
                break;
            case "Print":
                PrintClinic(clinics, inputArgs);
                break;
        }
    }

    private static void PrintClinic(List<Clinic> clinics, string[] inputArgs)
    {
        var clinicName = inputArgs[1];

        var clinic = clinics.FirstOrDefault(c => c.Name == clinicName);

        if (inputArgs.Length == 3)
        {
            var room = int.Parse(inputArgs[2]);

            Console.WriteLine(clinic.Print(room));
        }
        else
        {
            Console.WriteLine(clinic.Print());
        }
    }

    private static void CheckForEmptyRooms(List<Clinic> clinics, string[] inputArgs)
    {
        var clinicName = inputArgs[1];

        var clinic = clinics.FirstOrDefault(c => c.Name == clinicName);

        Console.WriteLine(clinic.HasEmptyRooms());
    }

    private static void ReleasePetFromClinic(List<Clinic> clinics, string[] inputArgs)
    {
        var clinicName = inputArgs[1];

        var clinic = clinics.FirstOrDefault(c => c.Name == clinicName);

        Console.WriteLine(clinic.Release());
    }

    private static void AddPetToClinic(List<Pet> pets, List<Clinic> clinics, string[] inputArgs)
    {
        var petName = inputArgs[1];
        var clinicName = inputArgs[2];

        var pet = pets.FirstOrDefault(p => p.Name == petName);
        var clinic = clinics.FirstOrDefault(c => c.Name == clinicName);

        Console.WriteLine(clinic.Add(pet));
    }

    private static void CreateElement(List<Pet> pets, List<Clinic> clinics, string[] inputArgs)
    {
        var toCreate = inputArgs[1];
        if (toCreate == "Pet")
        {
            var name = inputArgs[2];
            var age = int.Parse(inputArgs[3]);
            var kind = inputArgs[4];

            var pet = new Pet(name, age, kind);
            pets.Add(pet);
        }
        else if (toCreate == "Clinic")
        {
            var name = inputArgs[2];
            var roomsCount = int.Parse(inputArgs[3]);

            var clinic = new Clinic(name, roomsCount);
            clinics.Add(clinic);
        }
    }
}
