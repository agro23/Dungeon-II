using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using Dungeon.Models;

namespace Dungeon.Controllers
{
<<<<<<< HEAD
  public class GameController : Controller
  {
    // [HttpGet("/game")]
    // public ActionResult Index()
    // {
    // }
      [HttpGet("/game")]
=======
    public class GameController : Controller
    {
        [HttpGet("/game")]
>>>>>>> f87f433847a03afec11d8496ef172a4efba2a2d6
        public ActionResult Index()
        {
          // List<Room> allRooms = Room.GetAll();
          PC newPC = PC.Find(2);
          Console.WriteLine("in /game PC thinks its room # is: " + newPC.GetRoomId());

          Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
          Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
          //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
          myGame.Add("pc", PC.Find(newPC.GetId()));
          myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
          myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

          myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

          myMap = Game.GetMap();
          myGame.Add("map", myMap);

          Console.WriteLine("Room inside /game is: " + Room.Find(newPC.GetRoomId()).GetName());

          return View("GameIndex", myGame);
        }

        [HttpGet("/game/room/{roomId}")]
        public ActionResult Move(int roomId)
        {
          string message = "";
          PC newPC = PC.Find(2);
          Room tempRoom = Room.Find(roomId);
          if ( newPC.HasLight() )
          {
              newPC.SetRoomId(roomId);
              newPC.Update(newPC.GetName(), newPC.GetPCType(), newPC.GetHP(), newPC.GetAC(), newPC.GetDamage(), newPC.GetLVL(), newPC.GetEXP(), newPC.GetRoomId());
              Console.WriteLine("newPC thinks its room is: " + newPC.GetRoomId());
          }
          else
          {
              message="It's too dark to go that way";
          }
          Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
          Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
          //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
          myGame.Add("pc", PC.Find(newPC.GetId()));
          myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
          myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

          myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

          myMap = Game.GetMap();
          myGame.Add("map", myMap);

          Console.WriteLine("Room inside Move is: " + Room.Find(newPC.GetRoomId()).GetName());
          Console.WriteLine("in Move PC thinks its room # is: " + newPC.GetRoomId());

          // if (message !=""){
          //     <APPEND MESSAGE>
          // }

          return View("GameIndex", myGame);
        }

        // [HttpGet("/game/look/{roomId}")]
        // public ActionResult Look(int roomId)
        // {
        //
        //     PC newPC = PC.Find(2);
        //     newPC.SetRoomId(roomId);
        //     Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
        //     Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
        //     //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
        //     myGame.Add("pc", PC.Find(newPC.GetId()));
        //     myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
        //     myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
        //
        //     myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
        //
        //     myMap = Game.GetMap();
        //     myGame.Add("map", myMap);
        //
        //     Console.WriteLine("Room inside Look is: " + Room.Find(newPC.GetRoomId()).GetName());
        //     Console.WriteLine("in Look PC thinks its room # is: " + newPC.GetRoomId());
        //
        //     return View("Look", myGame);
        // }


        [HttpGet("/game/look/{roomId}")]
        public ActionResult Look(int roomId)
        {

          PC newPC = PC.Find(2);
          newPC.SetRoomId(roomId);
          Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
          Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
          //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
          myGame.Add("pc", PC.Find(newPC.GetId()));
          myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
          myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

          myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

          myMap = Game.GetMap();
          myGame.Add("map", myMap);
          return View("Look", myGame);
        }

      // myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
      //
      // myMap = Game.GetMap();
      // myGame.Add("map", myMap);
      //
      //
      // return View("GameIndex", myGame);

    //
    // [HttpGet("/game/room/{roomId}")]
    // public ActionResult Move(int roomId)
    // {
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //   Console.WriteLine("Passed Room Id data is: " + roomId);
    //   Console.WriteLine("PC's new room is: " + newPC.GetRoomId());
    //   Console.WriteLine("Room Lighted is: " + Room.Find(newPC.GetRoomId()).GetLight());
    //   Console.WriteLine("Room Name is: " + Room.Find(newPC.GetRoomId()).GetName());
    //   Console.WriteLine("Room 2's Name is: " + Room.Find(2).GetName());
    //
    //
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myGame);
    //
    //
    //   // return View("/game");
    //   return View("GameIndex", myGame);
    //
    //
    // }

    // [HttpGet("/game/room/{roomId}")]
    // public ActionResult Move(int roomId)
    // {
    //
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myMap);
    //   return View("GameIndex", myGame);
    // }

    // [HttpGet("/game/room/{roomId}")]
    // public ActionResult Move(int roomId)
    // {
    //
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myMap);
    //   return View("GameIndex", myGame);
    // }

    // [HttpGet("/game/look/{roomId}")]
    // public ActionResult Look(int roomId)
    // {
    //
    //   PC newPC = PC.Find(2);
    //   newPC.SetRoomId(roomId);
    //   Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
    //   Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
    //   //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
    //   myGame.Add("pc", PC.Find(newPC.GetId()));
    //   myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
    //   myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));
    //
    //   myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());
    //
    //   myMap = Game.GetMap();
    //   myGame.Add("map", myMap);
    //   return View("Look", myGame);
    // }

    [HttpGet("/game/inventory/{pcId}")]
    public ActionResult Inventory(int pcId)
    {

      PC newPC = PC.Find(2);
      List<Item> tempItems = newPC.GetItems();
      // newPC.SetRoomId(pcId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      myGame.Add("stuff", tempItems);

      return View("Inventory", myGame);
    }

   [HttpGet("/game/select/{roomId}")]
    public ActionResult Select(int roomId)
    {
      PC newPC = PC.Find(2);
      List<Item> newItem = newPC.GetItems();


      // newPC.SetRoomId(pcId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      myGame.Add("stuff", newItem);

      return View("Select", myGame);
    }

    [HttpGet("/game/select/{pcId}/{roomId}/{itemId}")]
    public ActionResult SelectItem(int pcId, int roomId, int itemId)
    {
      PC newPC = PC.Find(pcId);
      List<Item> newItem = newPC.GetItems();
      Item tempItem = Item.Find(itemId);
      newPC.AddItemToPC(Item.Find(itemId));
      tempItem.RemoveFromContents(itemId);

      // newPC.SetRoomId(pcId);
      Dictionary<int, int[]> myMap = new Dictionary<int, int[]>{};
      Dictionary<string, object> myGame = new Dictionary<string, object>{{"room", Room.Find(newPC.GetRoomId()) }};
      //           Dictionary<string, object> myGame = new Dictionary<string, object>{"room", Room.Find(PC.GetRoomId()) };
      myGame.Add("pc", PC.Find(newPC.GetId()));
      myGame.Add("npc", Game.GetAllNPCs(newPC.GetRoomId()));
      myGame.Add("item", Game.GetAllItems(newPC.GetRoomId()));

      myGame.Add("command", Room.Find(newPC.GetRoomId()).GetCommands());

      myMap = Game.GetMap();
      myGame.Add("map", myMap);
      myGame.Add("stuff", newItem);

      return View("Select", myGame);
    }
}
