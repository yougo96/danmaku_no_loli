﻿using UnityEngine;
using System.Collections;

public class enemy_proto1 : MonoBehaviour {

	public int vie = 10;
	public int Espeed = 5;
	public GameObject bullet;
	Renderer rend;
	double current_time = 0;
	double time_delayed = 0;
	double delay = 0.5;
	Color color;

	void Start () {

		color.r = color.g = color.b = color.a = 1;
		rend = GetComponent<Renderer>();

		GetComponent<Rigidbody2D>().velocity = transform.up.normalized * Espeed;
		Destroy (gameObject, 20);
	
	}

	void Update () {
		current_time += Time.deltaTime;
		if (current_time >= time_delayed) {
			time_delayed += delay;
			Instantiate (bullet, transform.position, transform.rotation);
		}
		if (vie <= 0) {
			GameObject.Find ("game_controller").GetComponent<ui_score>().score += 5;
			print ("score+5");
			Destroy (gameObject);
		}
		rend.material.color = color;
		if (color.b < 1f) {
			color.b = color.g += 0.1f;
		}
	}
		
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "playerbullet") {
			vie -= 1;
			color.b = color.g = 0;
		}
	}
}