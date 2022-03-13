using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransitionDestination : MonoBehaviour
{
    public enum DestinationTag
    {
        FOREST,VILLEGE,VILLEGEFIRE, VILLEGEFIRE_TRAPTOSAVE, TRANSPORT_01,
        TRANSPORT_01_2, TRANSPORT_02, TRANSPORT_02_2,DUNGEON,SEWER
    }

    public DestinationTag destinationTag;
}
