// Name:	ClientPseudocode
// Author:	Greg
// Created:	7/11/13
// Version:	1.0
// About:	Suggestion for running things client side
// 			Feel free to edit / comment

/****************************************************************/
startupScript.sh 	// could do all this in main program actually

wifi scan
if we can see access point
	connect, get IP using DHCP
	if can ping server
		launch client.c
exit

// not a good idea to put infinite loops in startup scripts so just try once

/****************************************************************/
client.c

setup()
{
	connect to server			// providing we're using tcp
	check keypad is attached
	check screen is attached
	
	while (1)
	{
		print "Please enter 4 digit pin"
		get input
		send input to server
		recv response from server
		if (pin accepted)
			break
		else
			print "Incorrect pin entered"
			// maybe lock out after 3 incorrect entries?
	}
	
	print "Which commentary level would you like?" // cannot be changed later
	get input
	switch case for level
	
	// same again for language maybe?
	
	request "how_to_use_equipment.mp3"
	
	play it		// don't think tracks are meant to autoplay but I think
				// this one should to tell them how to use device

	print "Do you understand???"
	get key press
		if 1:	// ok carry on
		if 2: 	// replay it
	
	return
}

main()
{
	setup()
	
	while (1)
	{
		sleep 2 secs?
		
		take wifi fingerprint
		if fingerprint is exit door???
		print "Thanks for taking tour"
			break
			
		if fingerprint is somewhere interesting AND not the same place as last check
			print "You are now in ..." 	// tell user where they are
			// "offer directional information about the nearest fire exit, staircase, toilets and coffee bar."
			
			kill previous audio thread
			start new audio thread
			update current location	
			
		// dont think anything else needs to go in here
	}
	return
}	
/****************************************************************/
audioThread.c 	// uses audio (ffmpeg?) library 
				// though it might be easier to just run the actual app and send it messages to pause etc?

audioThread
{
	request / buffer mp3
	
	print "Play now or wait for group?"
	get keypad press
	if	press 1		// just gonna say this is unicast for now
		// begin playback now
	if	press 2		// multicast
		wait for cue from server to begin playback	
		// either ask everyone to press 1 when ready
		// or begin when group leader presses


	// dont autoplay
	
	while (1) // keeps going until user moves somewhere new
	{
		wait for keypad press
		switch case keypad press 
			play / pause: 	// requirement
			stop:			// requirement
			rewind: 		// requirement
			fast forward:	// requirement
			seek time: 		// might be tricky not sure if worth it
			
			// spec says:
			// "The listener can evoke the guide track segments in any order by using the keypad."
			{
			1:				// track 1
			2:				// track 2
			3:				// track 3
			4:				// track 4
				stop current playback
				free mp3 from memory
				request new track
				// dont autoplay
			}
			
		// I'm not sure how best to update playback time to 7 seg yet, may need another thread
	}
}

sigkill handler()
{
	// handles kill request safely
	stop playback
	shutdown decoder
	free mp3 from memory
}
/****************************************************************/