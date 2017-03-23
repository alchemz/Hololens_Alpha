using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CalculatorScript : MonoBehaviour {

	Text resultText;
	double result= 0.0;
	//A temporary double, saving
	double tempSave;
	string operation;
	double multiplier =1;
	public double storeInt;


	// Use this for initialization
	void Start () {
		resultText = GameObject.Find ("Result").GetComponent<Text> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void writeTextField()
	{
		resultText.text = "" + result;
	}

	public void ClearResult()
	{
		result = 0.0;
		multiplier = 1;
		writeTextField ();
	}

	public void saveOperation(string o)
	{
		operation = o;
		tempSave = result;
		result = 0.0;
		multiplier = 1;
		//Display the operation character
		resultText.text=operation;
	}

	public void AddDigit(int d)
	{
		if (multiplier == 1) {
			result *= 10;
			result += d;
		} else 
		{
			result += d * multiplier;
			multiplier /= 10;
		}
		writeTextField ();
	}

	public void setMultiplier()
	{
		multiplier = 0.1;
	}

	public void CalcResult()
	{
		switch (operation) 
		{
		case "+":
			result = tempSave + result;
			break;
		case "-":
			result = tempSave - result;
			break;
		case "*":
			result = tempSave * result;
			break;
		case "/":
			result = tempSave / result;
			break;
		case "%":
			result = tempSave % result;
			break;
		case "√":
			result = Math.Sqrt (result);
			break;
		case "π":
			result = Math.PI;
			break;
		case "e":
			result = Math.E;
			break;
		case "sin":
			result = Math.Sin (result);
			break;
		case "cos":
			result = Math.Cos (result);
			break;
		case "tan":
			result = Math.Tan (result);
			break;
		case "off":
			UnityEditor.EditorApplication.isPlaying = false;
			break;
		case "=":
			result = result;
			break;
		}

		if (operation == "store")
			storeInt = tempSave;
		else if (operation == "restore")
			result = storeInt;
		

		//clear the operation, so it will not reitterate the operation
		operation ="";
		multiplier = 1;

		writeTextField ();
	}


}
