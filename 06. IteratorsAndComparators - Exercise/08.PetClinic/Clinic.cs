using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic
{
    private Pet[] pets;

    public Clinic(string name, int roomsCount)
    {
        this.Name = name;
        this.ValidateRoomsCount(roomsCount);
        this.RoomsCount = roomsCount;
        this.pets = new Pet[roomsCount];
    }

    public string Name { get; }

    public int RoomsCount { get; }

    public int CenterRoom => this.pets.Length / 2;

    public bool Add(Pet pet)
    {
        var currentRoom = this.CenterRoom;

        for (int i = 0; i < this.pets.Length; i++)
        {

            if (i % 2 != 0)
            {
                currentRoom -= i;
            }
            else
            {
                currentRoom += i;
            }


            if (this.pets[currentRoom] == null)
            {
                this.pets[currentRoom] = pet;
                return true;
            }
        }

        return false;
    }

    public bool Release()
    {
        for (int i = 0; i < this.pets.Length; i++)
        {
            var roomIndex = (this.CenterRoom + i) % this.pets.Length;

            var currentRoom = this.pets[roomIndex];

            if (currentRoom != null)
            {
                this.pets[roomIndex] = null;
                return true;
            }
        }

        return false;
    }

    public bool HasEmptyRooms()
    {
        return this.pets.Any(p => p == null);
    }

    public string Print(int room)
    {
        var result = this.pets[room - 1]?.ToString() ?? "Room empty";

        return result;
    }

    public string Print()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < this.pets.Length; i++)
        {
            sb.AppendLine(this.Print(i + 1));
        }

        var result = sb.ToString().TrimEnd();

        return result;
    }

    private void ValidateRoomsCount(int roomsCount)
    {
        if (roomsCount % 2 == 0)
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
    }
}