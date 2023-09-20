using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoManager : MonoBehaviour
{
    private ShipScript shipCore;
    private string shipType;
    public int CargoTypes;
    public string[] Cargo;
    public float[] CargoQuant;
    private string[] CargoList;

    /*
    CargoTypes: The number of different cargo types on the ship
    Cargo: The names of the cargo types on the ship
    CargoQuant: Quantity of each cargo type on the ship
    CargoList: A list of which cargo types a ship can spawn with. Different for each ship class.

    How this works:
    Each type has list of all possible types of cargo (CargoList[]),
    from this a maximum number of types (CargoTypes) is chosen and added to
    the actual cargo the ships spawns with (Cargo[]). The quantity for each
    cargo is generated in CargoGenerator(float maxtype), which is put into a
    list of floats called CargoQuant[].
     */

    void Start()
    {
        shipCore = gameObject.GetComponentInParent<ShipScript>();
        shipType = shipCore.ShipType;
        
        //all cargo types
        string[] cargoAll = new string[11] {"Metal Alloys", "Stellar Plasma", "Food", "Ammunition", "Organic Compounds", "Delicate Electronics", "Heat Sinks", "Curie Coolant", "Propellant", "Crew Equipment", "Heavy Machinery"};
        
        //generate cargo based on ship class
        switch (shipType)
        {
            case "Hauler":
                CargoList = new string[7] {cargoAll[0], cargoAll[2], cargoAll[4], cargoAll[5], cargoAll[6], cargoAll[9], cargoAll[10]};
                CargoGenerator(6);
                for (int i = 0; i < CargoTypes; i++)
                {
                    Cargo[i] = CargoList[Random.Range(0, CargoList.Length)];
                }
                break;

            case "Civillian":
                CargoList = new string[5] { cargoAll[2], cargoAll[3], cargoAll[4], cargoAll[7], cargoAll[9]};
                CargoGenerator(3);
                for (int i = 0; i < CargoTypes; i++)
                {
                    Cargo[i] = CargoList[Random.Range(0, CargoList.Length)];
                }
                break;

            case "Scientific":
                CargoList = new string[7] { cargoAll[1], cargoAll[2], cargoAll[3], cargoAll[5], cargoAll[7], cargoAll[8], cargoAll[9]};
                CargoGenerator(4);
                for (int i = 0; i < CargoTypes; i++)
                {
                    Cargo[i] = CargoList[Random.Range(0, CargoList.Length)];
                }
                break;

            case "Mining":
                CargoList = new string[7] { cargoAll[0], cargoAll[1], cargoAll[2], cargoAll[4], cargoAll[6], cargoAll[8], cargoAll[10] };
                CargoGenerator(4);
                for (int i = 0; i < CargoTypes; i++)
                {
                    Cargo[i] = CargoList[Random.Range(0, CargoList.Length)];
                }
                break;

            case "Military":
                CargoList = new string[8] { cargoAll[0], cargoAll[1], cargoAll[3], cargoAll[5], cargoAll[6], cargoAll[7], cargoAll[8], cargoAll[10] };
                CargoGenerator(5);
                for (int i = 0; i < CargoTypes; i++)
                {
                    Cargo[i] = CargoList[Random.Range(0, CargoList.Length)];
                }
                break;

            default:
                break;
        }
    }

    private void CargoGenerator(int maxtype)
    {
        //determines how many differnt types of cargo and sets that as the size of the arrays
        CargoTypes = Random.Range(1, maxtype);
        Cargo = new string[CargoTypes];
        CargoQuant = new float [Cargo.Length];

        //generates a quantity for each cargo
        int iter = 0;
        foreach (string cargo in Cargo)
        {
            CargoQuant[iter] = Random.Range(10, 100);
            iter++;
        }
    }
}
