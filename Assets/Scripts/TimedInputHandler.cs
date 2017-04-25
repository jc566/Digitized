using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; //required to use from event system ui object

public interface TimedInputHandler : IEventSystemHandler {

	void HandleTimedInput();
		
}
