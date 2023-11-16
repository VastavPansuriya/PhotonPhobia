using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wire : MonoBehaviour
{

    [SerializeField] private LineRenderer wire;
    [SerializeField] private float segLength;
    [SerializeField] private int wireCount;
    [SerializeField] private float lineWidth;

    private List<WireSegment> wires = new List<WireSegment>();


    Camera cm;

    private void Start()
    {
        cm = Camera.main;
        wire = GetComponent<LineRenderer>();
        Vector3 ropeStartPoint = cm.ScreenToWorldPoint(Input.mousePosition);

        for (int i = 0; i < wireCount; i++)
        {
            wires.Add(new WireSegment(ropeStartPoint));
            ropeStartPoint.y -= segLength;
        }
    }

    private void Update()
    {
        DrawRope();
    }
    private void DrawRope()
    {
        float lineWidth = this.lineWidth;
        wire.startWidth = lineWidth;
        wire.endWidth = lineWidth;

        Vector3[] ropPos = new Vector3[wireCount];
        for (int i = 0; i < wireCount; i++)
        {
            ropPos[i] = wires[i].newPos;
        }

        wire.positionCount = ropPos.Length;
        wire.SetPositions(ropPos);
    }
    public struct WireSegment
    {
        public Vector2 newPos;
        public Vector2 oldPos;

        public WireSegment(Vector2 pos)
        {
            this.newPos = pos;
            this.oldPos = pos;
        }
    }
}
