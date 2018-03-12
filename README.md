# steam-linker
Find new people, discover hidden friend circles, explore your friend network. This program helps you navigate friend networks on Steam.
By Howtoeatpineapples:76561198077279908

What it's used for:
1. Figuring out social circles on steam
2. Finding all IRL friend's steam accounts by adding a small list of your current IRL friends.
3. Finding out who associates with a person with a private profile; it's difficult to figure out who someone is if 
    they're private however inputing 2 users who have the private person added will result in a list of people who may
    be associated with that (private) person, thus reducing their anonymity.

Requirements:
1.  Steam web API key: https://steamcommunity.com/dev/apikey (applications are instantaneous)
2.  A list of friends you would like to network.
     This list must be made up of steamID64s of the users: 
     Vales can be separated using ( ' ', ',', '.', '\t', '\n', '-', ':' )  \t = tab & \n = linebreak
     eg input: 76561198062411111,76561198062411112,76561198062411113,76561198062411114 
     
Usage:
1. Input API key into top text box
2. Input your steamids into the larger text box
3. Press GO

Error?
All exceptions are returned to the end user so you can self diagnose or contact me for support.
Very long lists time out and are very buggy especially if there are any private profiles in your input
Private or friends-only input accounts will break the program so don't try it.

How it works?
All your inputs are collected together,
Each input's friendlist is generated,
Each input's friendlist is compared with every other input's friendlist (poor design, O = 2^x),
If any two people share a friend this mutual friend is added to a new list,
New list is parsed back through the web api and account details are retrieved.

Tip:
Result values can be added back into your initial search. (things start to get messy with lots of inputs, be warned!)
