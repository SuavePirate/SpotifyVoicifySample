# SpotifyVoicifySample
A sample webhook integration that talks between Voicify and Spotify for users who link their spotify account

# Requirements
To use this sample webhook you'll need:
- A voicify app
- A spotify app
- Account linking wired up in Alexa, Google Assistant, etc.
- Add a conversation item with the webhook in Voicify

# Features
This currently has one sample endpoint that lets you query for the current user and replace the {username} response with their actual Spotify name
For example:
![sample voicify image](/image.png)

Which then would result in the output:
![sample alexa output](/sample_alexa.png)
