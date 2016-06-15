/*============================================================================== 
 * Copyright (c) 2012-2015 Qualcomm Connected Experiences, Inc. All Rights Reserved. 
 * ==============================================================================*/
using UnityEngine;
using Vuforia;

/// <summary>
/// A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
public class TrackableEventHandler : MonoBehaviour, ITrackableEventHandler
{
    #region PRIVATE_MEMBERS
    private TrackableBehaviour mTrackableBehaviour;
    private bool mHasBeenFound = false;
    private bool mLostTracking;
    private float mSecondsSinceLost;
	private VideoPlaybackBehaviour ThisVid;
	public GameObject ARCamera;
	public GameObject SecondCamera;
    #endregion // PRIVATE_MEMBERS


    #region MONOBEHAVIOUR_METHODS

    void Start()
    {
		VideoLayer = Particles.gameObject.layer;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
        {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        OnTrackingLost();

    }
	public GameObject RelatedVideoScreen;
	public GameObject LineEffect;
	public ParticleSystem Particles;
	int VideoLayer;
    #endregion //MONOBEHAVIOUR_METHODS


    #region PUBLIC_METHODS
    /// <summary>
    /// Implementation of the ITrackableEventHandler function called when the
    /// tracking state changes.
    /// </summary>
	 
	public void CloseVideos(){
		PauseOtherVideos (null);
	}

    public void OnTrackableStateChanged(
                                    TrackableBehaviour.Status previousStatus,
                                    TrackableBehaviour.Status newStatus)
    {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }
    #endregion //PUBLIC_METHODS


    #region PRIVATE_METHODS
    private void OnTrackingFound()
    {
		
		Particles.gameObject.layer = 0;
		Particles.Stop ();
		LineEffect.SetActive (false);

		PauseOtherVideos (null);


		if (ThisVid != null) {
			ThisVid.VideoPlayer.Play(false, RelatedVideoScreen.GetComponent<VideoPlaybackBehaviour>().VideoPlayer.GetCurrentPosition());
		}

		ARCamera.GetComponent<VideoPlaybackController> ().enabled = true;
		SecondCamera.GetComponent<VideoPlaybackController> ().enabled = false;

		if (RelatedVideoScreen.GetComponent<VideoPlaybackBehaviour> ().VideoPlayer.GetStatus () == VideoPlayerHelper.MediaState.PLAYING) {
			RelatedVideoScreen.GetComponent<VideoPlaybackBehaviour> ().VideoPlayer.Pause ();
		}
		 
		ThisVid = GetComponentInChildren<VideoPlaybackBehaviour> ();

		RelatedVideoScreen.GetComponent<SetUpSecondScreen> ().Normalized = true;

		RelatedVideoScreen.GetComponent<Renderer> ().enabled = false;
		RelatedVideoScreen.GetComponent<Collider> ().enabled = false;



		Renderer[] rendererComponentsReleted = RelatedVideoScreen.GetComponentsInChildren<Renderer>();
		Collider[] colliderComponentsReleted = RelatedVideoScreen.GetComponentsInChildren<Collider>();

		// Enable rendering:
		foreach (Renderer component in rendererComponentsReleted)
		{
			component.enabled = false;
		}

		// Enable colliders:
		foreach (Collider component in colliderComponentsReleted)
		{
			component.enabled = false;
		}




		ButtonFunction[] UIArray = (ButtonFunction[])FindObjectsOfType<ButtonFunction> ();

		for (int pass = 0; pass < UIArray.Length; pass++) {
			UIArray [pass].gameObject.GetComponent<Renderer> ().enabled = false;
			UIArray [pass].gameObject.GetComponent<Collider> ().enabled = false;
		}
        Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();

        // Enable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = true;
        }

        // Enable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = true;
        }
		
        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");

        // Optionally play the video automatically when the target is found

        
		if (ThisVid != null && ThisVid.AutoPlay)
        {
			if (ThisVid.VideoPlayer.IsPlayableOnTexture())
            {
				VideoPlayerHelper.MediaState state = ThisVid.VideoPlayer.GetStatus();
                if (state == VideoPlayerHelper.MediaState.PAUSED ||
                    state == VideoPlayerHelper.MediaState.READY ||
                    state == VideoPlayerHelper.MediaState.STOPPED)
                {
                    // Pause other videos before playing this one
					PauseOtherVideos(ThisVid);

                    // Play this video on texture where it left off

					ThisVid.VideoPlayer.Play(false, RelatedVideoScreen.GetComponent<VideoPlaybackBehaviour>().VideoPlayer.GetCurrentPosition());
                }
                else if (state == VideoPlayerHelper.MediaState.REACHED_END)
                {
                    // Pause other videos before playing this one
					PauseOtherVideos(ThisVid);

                    // Play this video from the beginning
					ThisVid.VideoPlayer.Play(false, 0);
                }
            }
        }

        mHasBeenFound = true;
        mLostTracking = false;
    }

    private void OnTrackingLost()
	{

		ARCamera.GetComponent<VideoPlaybackController> ().enabled = false;
		SecondCamera.GetComponent<VideoPlaybackController> ().enabled = true;

		Renderer[] rendererComponents = GetComponentsInChildren<Renderer>();
        Collider[] colliderComponents = GetComponentsInChildren<Collider>();


        // Disable rendering:
        foreach (Renderer component in rendererComponents)
        {
            component.enabled = false;
        }

        // Disable colliders:
        foreach (Collider component in colliderComponents)
        {
            component.enabled = false;
        }

        Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
		if (ThisVid != null) {
			ThisVid.VideoPlayer.Pause ();
		}

		RelatedVideoScreen.GetComponent<VideoPlaybackBehaviour> ().VideoPlayer.Play (false, ThisVid.VideoPlayer.GetCurrentPosition ());

		RelatedVideoScreen.GetComponent<Renderer> ().enabled = true;
		RelatedVideoScreen.GetComponent<Collider> ().enabled = true;

		Renderer[] rendererComponentsRelated = RelatedVideoScreen.GetComponentsInChildren<Renderer>();
		Collider[] colliderComponentsRelated = RelatedVideoScreen.GetComponentsInChildren<Collider>();


		// Disable rendering:
		foreach (Renderer component in rendererComponentsRelated)
		{
			component.enabled = true;
		}

		// Disable colliders:
		foreach (Collider component in colliderComponentsRelated)
		{
			component.enabled = true;
		}



        mLostTracking = true;
		/*
        mSecondsSinceLost = 0;
        */
    }



    // Pause all videos except this one
    private void PauseOtherVideos(VideoPlaybackBehaviour currentVideo)
    {
        VideoPlaybackBehaviour[] videos = (VideoPlaybackBehaviour[])
                FindObjectsOfType(typeof(VideoPlaybackBehaviour));

        foreach (VideoPlaybackBehaviour video in videos)
        {
			if (video != currentVideo)
            {
				video.gameObject.GetComponent<Renderer> ().enabled = false;
				video.gameObject.GetComponent<Collider> ().enabled = false;

				Renderer[] rendererComponents = video.gameObject.GetComponentsInChildren<Renderer>();
				Collider[] colliderComponents = video.gameObject.GetComponentsInChildren<Collider>();


				// Disable rendering:
				foreach (Renderer component in rendererComponents)
				{
					component.enabled = false;
				}

				// Disable colliders:
				foreach (Collider component in colliderComponents)
				{
					component.enabled = false;
				}

                if (video.CurrentState == VideoPlayerHelper.MediaState.PLAYING)
                {
                    video.VideoPlayer.Pause();

                }
            }
        }
    }
    #endregion //PRIVATE_METHODS
}
