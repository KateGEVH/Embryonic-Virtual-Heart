using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendShapes : MonoBehaviour
int currentBlend=1;
int blendShapeCount;
SkinnedMeshRenderer skinnedMeshRenderer;
Mesh skinnedMesh;


void Awake()
	{
	skinnedMeshRenderer = GetComponent<SkinnedMeshRenderer>();
	skinnedMesh = GetComponent<SkinnedMeshRenderer>().sharedMesh;
	}

void Start()
	{
	blendShapeCount = skinnedMesh.blendShapeCount;
		
	if (blendShapeCount < 1) 
		{
		Debug.LogError("Get your blendshapes in order!");
		Destroy(this);
		}
	}

public void SetDistortedState(float onPercentage)
	{
	skinnedMeshRenderer.SetBlendShapeWeight(0, onPercentage);
	float distortedPercentage = Mathf.Abs(onPercentage - 1f);
	skinnedMeshRenderer.SetBlendShapeWeight(currentBlend, distortedPercentage);
	}

public void SetCurrent(int blendIndex)
	{
	currentBlend = blendIndex;
	}
}
