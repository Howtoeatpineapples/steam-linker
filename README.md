# steam-linker
Find new people, discover hidden friend circles, explore your friend network. This program helps you navigate friend networks on Steam.

What it's used for:
1. Figuring out social circles on steam
2. Finding new friends
3. Deanonymizing cheaters with private profiles 

Requirements:
1.  Your Steam web API key, which you can get from here: https://steamcommunity.com/dev/apikey
2.  A list of friends you would like to network.
     This list must be made up of steamID64s of the users: 
     Vales can be separated using one of the following delimiters ( ' ', ',', '.', '\t', '\n', '-', ':' )  \t = tab & \n =  linebreak
     example input: 76561198062411111,76561198062411112,76561198062411113,76561198062411116
     
Usage:
1. Input API key into top text box
2. Input your steamids into the larger text box
3. Press GO

Errors:
All exceptions are returned to the end user so you can self diagnose or contact me for support.
Very long lists time out and are very buggy especially if there are any private profiles in your input.
Private or friends-only input accounts will break the program so don't try it.

How it works:
All your input users are collected together,
Each input user's friendlist is generated using your api key,
Each input user's friendlist is compared with every other input user's friendlist,
If any two people share a friend this mutual friend is added to a new list,
the new list is passed back through the web api and account details are retrieved (username, profile icon, etc).

