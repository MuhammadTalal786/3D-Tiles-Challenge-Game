using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
	public UnityEvent buttonClick;

	public object OnClick { get; internal set; }

	private void Awake()
	{
		if(buttonClick != null) { buttonClick=new UnityEvent(); }
	}
	void OnMouseUp()
	{
		print("Click");
	}

	internal void SetActive(bool v)
	{
		throw new NotImplementedException();
	}
}
