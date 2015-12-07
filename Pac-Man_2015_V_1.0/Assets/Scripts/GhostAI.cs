using UnityEngine;
using System.Collections;

public class GhostAI : MonoBehaviour {

	//Controlls all ghost behaviour

	public GameObject visualizerAlive, visualizerScared, visualizerDead;
	public GameObject orientator; 
	public int orientation;
	public Vector3 startPos;
	public StatsManager SM;

	public Transform curTarget,playerTarget,insideNestTarget,outsideNestTarget;
	public Transform targetAssistFront, targetAssistRight, targetAssistLeft;

	public float speed = 3f; // <- Just a recommended base speed. Feel free to change to whatever feels right.
	float curSpeed;
	Vector3 curDirection;

	public Detect front,close,rightSide,leftSide;

	public bool collided;
	public float collideCooldown;
	public float setCollideCooldown;
	 
	public bool ghostAwake;
	public float setAwakeTime;
	public float awakeTime;

	public bool ghostEatable;
	public float setEatableTime;
	public float eatableTime;

	public bool ghostAlive;

	// Use this for initialization
	void Start () {

		SM = GameObject.Find ("_statsManager").GetComponent<StatsManager> ();

		setEatableTime -= SM.curLvl * 2;
		if (setEatableTime < 5) {
			setEatableTime = 5;
		}
		curSpeed = 0;

		startPos = transform.position;

		playerTarget =  GameObject.FindGameObjectWithTag("Player").transform;

		insideNestTarget = GameObject.FindGameObjectWithTag("NestTargetInside").transform;
		outsideNestTarget = GameObject.FindGameObjectWithTag("NestTargetOutside").transform;

		ChangeDirection(0+orientation);
	}
	
	// Update is called once per frame
	void Update () {

		if(!ghostAwake){
			if(awakeTime > 0){
				awakeTime -= Time.deltaTime;
			}else{

				AwakenGhost();
			}
		}

		if(ghostEatable && eatableTime > 0){
			eatableTime -= Time.deltaTime;
		}else if(ghostEatable && eatableTime <= 0){

			StartGhost();
		}

		//Eliminates random, physics based motion
		GetComponent<Rigidbody>().velocity = Vector3.zero;

		transform.Translate(curDirection * curSpeed * Time.deltaTime,Space.Self);

		// Checks for decision events 
		if(!collided && ghostAwake && (rightSide.WayClear() || leftSide.WayClear())){
			
			if(!front.WayClear()){
				
				if(rightSide.WayClear() && leftSide.WayClear()){

					ChangeDirection(AIDecision(0) + orientation);
					
				}else if(rightSide.WayClear()){
					
					ChangeDirection(1+orientation);
					
				}else if(leftSide.WayClear()){
					
					ChangeDirection(3+orientation);
				}
				
			}else if(front.WayClear()){
				
				if(rightSide.WayClear() && leftSide.WayClear()){
					
					ChangeDirection(AIDecision(3) + orientation);
					
				}else if(rightSide.WayClear()){
					
					ChangeDirection(AIDecision(1) + orientation);
					
				}else if(leftSide.WayClear()){
					
					ChangeDirection(AIDecision(2) + orientation);
				}
			}

		}else if(!close.WayClear() && !collided && ghostAwake){

			ChangeDirection(2+orientation);	
		}

		if(collideCooldown > 0){
			collideCooldown -= Time.deltaTime;
		}else{
			collided = false;
		}
	}
	
	void ChangeDirection(int _direction){

		collided = true;
		collideCooldown = setCollideCooldown;

		_direction = OrientationCheck(_direction);

		if(_direction == 0){
			orientator.transform.rotation = Quaternion.Euler(0,0,0);
			curDirection = Vector3.forward;
			orientation = 0;
		}else if(_direction == 1){
			orientator.transform.rotation = Quaternion.Euler(0,90,0);
			curDirection = Vector3.right;
			orientation = 1;
		}else if(_direction == 2){
			orientator.transform.rotation = Quaternion.Euler(0,180,0);
			curDirection = Vector3.back;
			orientation = 2;
		}else if(_direction == 3){
			orientator.transform.rotation = Quaternion.Euler(0,270,0);
			curDirection = Vector3.left;
			orientation = 3;
		}
	}
	int OrientationCheck(int _i){

		if(_i >= 4){
			_i -= 4;
		}
		return _i; 
	}
	
	//	AI decision making
	int AIDecision(int _pathOptionsState){

		int _toTurn = 0;
		
		if(_pathOptionsState == 0 && !ghostEatable){
			
			if(Vector3.Distance(curTarget.position,targetAssistRight.position)
			   < Vector3.Distance(curTarget.position,targetAssistLeft.position)){
				
				_toTurn = 1;
				
			}else{
				
				_toTurn = 3;
			}
		
		}else if(_pathOptionsState == 0 && ghostEatable){
			
			if(Vector3.Distance(curTarget.position,targetAssistRight.position)
			   > Vector3.Distance(curTarget.position,targetAssistLeft.position)){
				
				_toTurn = 1;
				
			}else{
				
				_toTurn = 3;
			}
			
		}else if(_pathOptionsState == 1 && !ghostEatable){

			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
			   < Vector3.Distance(curTarget.position,targetAssistRight.position)){
				
				_toTurn = 0;
				
			}else{
				
				_toTurn = 1;
			}

		}else if(_pathOptionsState == 1 && ghostEatable){
			
			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
			   > Vector3.Distance(curTarget.position,targetAssistRight.position)){
				
				_toTurn = 0;
				
			}else{
				
				_toTurn = 1;
			}

		}else if(_pathOptionsState == 2 && !ghostEatable){

			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
			   < Vector3.Distance(curTarget.position,targetAssistLeft.position)){
				
				_toTurn = 0;
				
			}else{
				
				_toTurn = 3;
			}
		
		}else if(_pathOptionsState == 2 && ghostEatable){
				
			if(Vector3.Distance(curTarget.position,targetAssistFront.position) 
			   > Vector3.Distance(curTarget.position,targetAssistLeft.position)){
					
				_toTurn = 0;
					
			}else{
					
				_toTurn = 3;
			}
			
		}else if(_pathOptionsState == 3 && !ghostEatable){

			if(Mathf.Min(Vector3.Distance(curTarget.position,targetAssistRight.position),
			             Vector3.Distance(curTarget.position,targetAssistLeft.position)) 
			   			> Vector3.Distance(curTarget.position,targetAssistFront.position)){

				_toTurn = 0;

			}else{

				if(Vector3.Distance(curTarget.position,targetAssistRight.position) 
				   < Vector3.Distance(curTarget.position,targetAssistLeft.position)){
					
					_toTurn = 1;
					
				}else{
					
					_toTurn = 3;
				}
			}

		}else if(_pathOptionsState == 3 && ghostEatable){
			
			if(Mathf.Min(Vector3.Distance(curTarget.position,targetAssistRight.position),
			             Vector3.Distance(curTarget.position,targetAssistLeft.position)) 
			   > Vector3.Distance(curTarget.position,targetAssistFront.position)){
				
				_toTurn = 0;
				
			}else{
				
				if(Vector3.Distance(curTarget.position,targetAssistRight.position) 
				   > Vector3.Distance(curTarget.position,targetAssistLeft.position)){
					
					_toTurn = 1;
					
				}else{
					
					_toTurn = 3;
				}
			}
		}

		return _toTurn;
	}

	//
	//	Ghost States
	//

	void OnCollisionStay(Collision other){

		if(other.gameObject.tag =="Ghost" && !collided && ghostAlive){

			Debug.Log("Collided with an other ghost");
			ChangeDirection(2+orientation);	

		}else if(ghostEatable && other.gameObject.tag == "Player"){

			KillGhost();
		}
	}


	void OnTriggerEnter(Collider other){

		if(!ghostAlive && ghostAwake && other.tag == "NestTargetInside"){

			AwakenGhost();

		}else if(/**ghostAlive &&*/ !ghostEatable && other.tag == "NestTargetOutside"){

			StartGhost();
		}
	}

	public void AwakenGhost(){

		ghostAwake = true;
		curTarget = outsideNestTarget;
		curSpeed = speed * 0.5f;
	}

	public void StartGhost(){

		visualizerAlive.SetActive(true);
		visualizerScared.SetActive(false);
		visualizerDead.SetActive (false);

		ghostEatable = false;
		ghostAlive = true;
		curTarget = playerTarget;
		curSpeed = speed;
	}

	public void ScareGhost(){

		if(ghostAlive && !ghostEatable){
			visualizerAlive.SetActive(false);
			visualizerScared.SetActive(true);
			ghostEatable = true;
			eatableTime = setEatableTime;
			ChangeDirection (2 + orientation);	
		}
	}

	public void KillGhost(){

		visualizerDead.SetActive (true);
		visualizerScared.SetActive (false); 

		ChangeDirection(2+orientation);	
		ghostAlive = false;
		ghostEatable = false;
		eatableTime = 0;
		curTarget = outsideNestTarget;
		curSpeed = speed * 1.0f;
	}

	public void RestartGhost(){

		ghostAlive = false;
		ghostAwake = false;
		ghostEatable = false;

		curSpeed = 0;

		visualizerAlive.SetActive(true);
		visualizerScared.SetActive(false);

		transform.position = startPos;
		ChangeDirection(0);
		awakeTime = setAwakeTime;

	}
}