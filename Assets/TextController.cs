using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	private enum States {cell, sheets_1, mirror, sheets_0, cell_mirror, lock_0, lock_1,
						 corridor_1, corridor_0, floor, stairs_0, stairs_1, stairs_2, corridor_2, corridor_3, closet_door, in_closet, courtyard };
	private States myState;
	public Text text;

	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if		(myState == States.cell)				{cell();}
		else if	(myState == States.sheets_0)			{sheets_0();}
		else if	(myState == States.lock_0)				{lock_0();}
		else if	(myState == States.mirror)				{mirror();}
		else if (myState == States.cell_mirror)			{cell_mirror();}
		else if	(myState == States.sheets_1)			{sheets_1();}
		else if	(myState == States.lock_1)				{lock_1();}
		else if	(myState == States.corridor_0)			{corridor_0();}
		else if	(myState == States.stairs_0)			{stairs_0();}
		else if	(myState == States.floor)				{floor();}
		else if	(myState == States.closet_door)			{closet_door();}
		else if	(myState == States.corridor_1)			{corridor_1();}
		else if (myState == States.stairs_1)			{stairs_1();}
		else if (myState == States.stairs_2)			{stairs_2();}
		else if (myState == States.in_closet)			{in_closet();}
		else if (myState == States.corridor_2)			{corridor_2();}
		else if (myState == States.corridor_3)			{corridor_3();}
		else if (myState == States.courtyard)			{courtyard();}
	}

	#region State handler region
	void cell(){
		text.text = "You are in a prison cell and trying to escape " +
					"There are some dirty sheets on the bed, a small mirror on top of them and the door.\n\n" +
					"Press S to view Sheets; Press M to look at the Mirror; Press L to look at the Lock";
		if		(Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_0;}
		else if (Input.GetKeyDown(KeyCode.L))		{myState = States.lock_0;}
		else if	(Input.GetKeyDown(KeyCode.M))		{myState = States.mirror;}
	}

	void sheets_0(){
		text.text = "You can't sleep in these things, somebody should change them.\n\n " + 
					"Press R to return to roaming your Cell";
		if		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
	}
	void lock_0(){
		text.text = "The cell door is locked. You need to find the key.\n\n"+
					"Press R to return to roaming your Cell";
		if		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell;}
	}

	void mirror(){
		text.text = "You are inspecting the dirty mirror.\n\n" +
					"Press R to let the mirror down and Return Roaming your cell, Press T to Take the Mirror";
		if		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell;} 
		else if	(Input.GetKeyDown(KeyCode.T))		{myState = States.cell_mirror;}
	}

	void cell_mirror(){
		text.text = "You took the dirty mirror. Try to find your way out.\n\n" + 
					"Press S to look at the sheets, Press L to look at the Lock";
		if		(Input.GetKeyDown(KeyCode.S))		{myState = States.sheets_1;}
		else if	(Input.GetKeyDown(KeyCode.L))		{myState = States.lock_1;}
	}

	void sheets_1(){
		text.text = "You cleaned the mirror with the dirty sheets.\n\n" +
					"Press R to return to roaming your cell";
		if		(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;}
	}

	void lock_1(){
		text.text = "The lock does not look sturdy.\n\n"+
					"Press O to force the lock with the mirror, Press R to Return";
		if		(Input.GetKeyDown(KeyCode.O))		{myState = States.corridor_0;}
		else if	(Input.GetKeyDown(KeyCode.R))		{myState = States.cell_mirror;}
	}
	void corridor_0(){
		text.text = "You have succesfully broke the lock! You can see some stairs going down and a closet door\n\n" + 
				"Press S to go down the stairs, C to open the closet door or I to inspect the Floor.";
		if		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_0;}
		else if (Input.GetKeyDown(KeyCode.C))		{myState = States.closet_door; }	
		else if (Input.GetKeyDown(KeyCode.I))		{myState = States.floor;}
	}
	
	void stairs_0(){
		text.text = "You can hear voices downstairs, you will be spotted if you go there.\n\n" +
					"Press B to go back.";
		if		(Input.GetKeyDown(KeyCode.B))		{myState = States.corridor_0;}
	}

	void closet_door(){
		text.text = "The door is locked.\n\n" + 
					"Press B to go back.";
		if 		(Input.GetKeyDown(KeyCode.B))		{myState = States.corridor_0;}
	}

	void floor(){
		text.text = "There is a hairclip on the floor\n\n" +
					"Press P to pickup the hairclip or B to go back";
		if		(Input.GetKeyDown(KeyCode.P))		{myState = States.corridor_1;}
		else if (Input.GetKeyDown(KeyCode.B))		{myState = States.corridor_0;}
	}

	void in_closet(){
		text.text = "You entered the closet. You found a janitor uniform.\n\n" +
					"Press D to dress or B to go back to the corridor.";
		if		(Input.GetKeyDown(KeyCode.D))		{myState = States.corridor_3;}
		else if (Input.GetKeyDown(KeyCode.B))		{myState = States.corridor_2;}
	}

	void corridor_1(){
		text.text = "You are on the corridor, you can pick the closet door or go down the stairs.\n\n" +
					"Press S to go downstairs or C to go to the closet door.";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_1;}
		else if (Input.GetKeyDown(KeyCode.C))		{myState = States.in_closet;}
	}

	void corridor_2(){
		text.text = "You have returned to the corridor. You can go back to the closet or down the stairs.\n\n" + 
					"Press S to go downstairs or C to go to the closet.";
		if 		(Input.GetKeyDown(KeyCode.S))		{myState = States.stairs_2;}
		else if	(Input.GetKeyDown(KeyCode.C))		{myState = States.in_closet;}
	}

	void corridor_3(){
		text.text = "You have disguised as a janitor and returned to the corridor.\n\n" +
					"Press U to undress the disguise or press S to go downstairs.";
		if		(Input.GetKeyDown(KeyCode.U))		{myState = States.in_closet;}
		else if (Input.GetKeyDown(KeyCode.S))		{myState = States.courtyard;}
	}

	void stairs_1(){
		text.text = "You can hear voices downstairs, you will be spotted if you go there.\n\n" +
					"Press B to go back.";
		if		(Input.GetKeyDown(KeyCode.B))		{myState = States.corridor_1;}
	}

	void stairs_2(){
		text.text = "You can hear voices downstairs, you will be spotted if you go there.\n\n" +
					"Press B to go back.";
		if		(Input.GetKeyDown(KeyCode.B))		{myState = States.corridor_2;}
	}

	void courtyard(){
		text.text = "You passed near two guards and they did not recognize you. "+
					"You are now in the courtyard.\n\n" +
					"Press P to Play again.";
		if		 (Input.GetKeyDown(KeyCode.P)) 		{myState = States.cell;}
	}
#endregion
}