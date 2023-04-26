using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ECE264AdventureGame2023.PlayerPrompt.Directions;

namespace ECE264AdventureGame2023
{
    class PlayerPrompt
    {

        /*
         
        need to make big ass switch case statement
        
        0-99 will be room discovery

        100-199 will be dialogue and interactions in rooms

        200-299 will be events

        300-399 will be secret interactions

        400-499 will be 
         
         
         */

        //Libraries




        //Declaring Rooms and CurrentRoom to be in




        //-Prior to entering room 1:-
        //PA: Hello. Welcome to the Uprall Transport Hub. Please enter your name"
        //player prompt for name
        //PA: Hello (player name), where would you like to go?
        //present choices for {Helio City} {I don't know where}

        // -if {Helio City}: -
           //You: Helio City, please
           //PA: Travelling to Helio City,please take your seat.
           //-enter room 1-

        //-if {I don't know where}-
            //You: Uh, I'm not really sure. Maybe I'll visit Uprall some other time.
            //PA: Thank you, have a good day.
            .
            .
            .
            //Ending 0: The Road Untravelled
        static Room room1 = new Room { Name = "Room1", Description = "You've made it to Helio City, Uprall's capital" };

        static Room room2 = new Room { Name = "Room2", Description = "You enter the back ally" };
        /*You: That guy in the hood. Who is he?
          As you step toward him, he turns around and sharpens his gaze
          ???: Who are you?

          -present choice-
            //{I'm nobody}
                //You: Oh, uh, I'm just nobody
                //???: Uh huh. And a "nobody" followed a hooded man into a back ally? Is "nobody" stupid?
                //You: Uh, no. Curiosity I guess. My name's {name}. Can I ask yours?
            //{I'm passing through}
                //You: I'm just passing through. My name's {name}
                //???: Just passing through huh? Getting seen with me is dangerous here in Uprall.
                //You: And who exactly are you?

        //???: ...You can call me Zrkka.
          Zrrka stares at you for a short time, and eventually asks;
        //Zrkka: 'The Steel Reaper'. Does that name mean anything to you?

        //-present choice- 
            //{Yes}
                //You: Yes, I know exactly who that is.
                //Zrkka: In that case...
                //Zrrka extends his arm toward you, sharp blades extending out from his wrist.
                //Zrrka: Their reach has gone farther than I thought. You're clearly a new recruit, so let me give you some advice: Don't follow me, if you value your life.
                  You: What are you-?
                  Zrkka walks toward you, blades extended
                  Zrkka: If I were you, I'd keep walking.
                  You: Ok, ok, I'm going.
                  Zrkka keeps his eye on you as he leaves the ally by climbing over a gate. Given the gate's height, he clearly wasn't human.
                  You: Ok then...moving on.
           {No}
                You: No, it doesn't. Is...that some kind of superhero?
                Zrkka stares at you some more, you notice his eyes glow red.
                Zrkka: Heartbeat stable, minimal perspiration. Unless you're a professional liar, you're telling me the truth.
                You: Are you the Steel Reaper?
                Zrkka: I suppose since you're here, you've gotten yourself roped into everything. Yes, I am.
                Zrkka removes his hood to reveal an almost completely cybernetic body
                Zrkka: I used to be a member of the Cyber Directive, a group of Uprallans who belive they can cyberize the whole world, so they can bend it to their will. 
                You: 'Used to be'? Why'd you quit?
                Zrkka: During a mission, something went wrong, and I got my autonomy back. Whatever control they had over me is gone, and now I fight back against them.
                You: Wait...you said I'm roped up in all this now?
                Zrkka: They've got eyes everywhere, and since you're here with me, they're after you now. So your best bet is to help me out.
                You: Yeah...I guess so.
                Zrkka: Here, take this. It'll help you see things in Uprall that they don't want you to see. It'll come in handy, I'm sure.
                You recieved the Cyber Lens!
                Zrkka: A friend of mine is patrolling the city as well. It's likely you'll run into him. He'll need your trust, or else he'll kill you. 
                You: That's comforting. How do I get his trust?
                Zrkka: He'll ask you a question, you give him the answer. The answer is '112'.
                You: 112. Got It. How will I know this friend of yours.
                Zrkka: Oh, you'll know. His bite is a lot worse than his bark.
                With a chuckle, Zrkka left the ally by jumping over a large gate.
                */

        static Room room3 = new Room { Name = "Room3", Description = "You continue through the square" };
        /*
         -Occurs upon entering the room every time you enter, unless the coin or secret coin is in inventory-
            As you walk through the square, you notice a coin shining on the ground.
            You: Hey, a coin. Everything is supposed to be digital in Uprall. What's this doing here?
            -present choice-
            {take coin}
                You recieved the coin!
            {Leave coin}
         * 
         * 
         -occurs if room is inspected with coin or secret coin in inventory- 
            -given option to approach vendor-
            -if vendor is approached-
            Abhi: Hello there, my name is Abhi, I am a humble vendor here in Uprall. How are you?
            You: I am doing fine, thank you. Can you tell me anything about this coin?
            Abhi: Of course! Let me see it! Oh, yes, yes, this coin is made of fine material! I will sell it to you for 500 credits!
            -present choice-
                {Sell the coin}
                    You: Yeah, sure, here ya go. 
                    You lost the coin!
                    You gain 500 credits!
                    Abhi: Pleasure doing business with you!
                {Don't sell the coin}
                    You: Actually, I think I'll hold onto it. A memento of my time here, I suppose. Thank you!
                    Abhi: Of course! Take care now!        
         */

        static Room room4 = new Room { Name = "Room4", Description = "You reach a road leading east" };
        /*
            -occurs when you try to go East WITH the coin or secret coin in inventory-
                Out of nowhere, a cyborg steps out of the shadows
                ???: That coin you've got there doesn't belong to you. I would like it back, if you don't mind.
                You: Who are you?
                ???: Not that it matters, but my name is Cyclone. 
                Cyclone: Now, be good and give me the coin.      
            -present choice-
                {Yes}
                    You: Uh, yeah, sure, here.
                    Cyclone: Good. Now, just pretend you never saw me, got it?
                    You: Yeah, sure. You got it.
                    With a wicked smile, Cyclone leaves.
                {No}
                    You: Sorry, but I'd rather not.
                    Cyclone: I would change my mind if I were you.
                    As he speaks, he walks toward you, revealing what appear to be daggers. In fear, you run into a side ally, hoping for a way to escape.
                    You run into a dead end, unable to escape as Cyclone slowly approaches you.
                    Cyclone: I gave you a chance. Oh well.

                    -if cyber lens is not in your inventory-
                    You feel the pain of cyclone's daggers as you collapse to the ground. Cyclone walking away with the coin is the last thing you see.
                    .
                    .
                    .
                    Bad End: Cold And Alone

                    -if cyber lens is in your inventory-
                    Out of nowhere, Zrkka drops into the ally and grabs cyclone, giving you an opportunity to escape.
                    Zrkka: Go!
                    Without thinking, you run past the two cyborgs and into the open street.
                    -travel to room 5-
         */

        static Room room5 = new Room { Name = "Room5", Description = "You've reached a long road" };
        /*          
                    -if above event happens-
                    After some time, Zrkka walks out of the ally.
                    Zrkka: I see you've met Cyclone.
                    You: Is he a part of the directive?
                    Zrkka: Yep. One of their enforcers. I'm gonna keep a closer eye on you, just in case. 
                    Zrkka turns toward the ally
                    Zrkka: Oh, that ally should be safe for you to go into. I don't know why you would, but it's there. I need you to head to the Firioris building. That's their headquarters, and that's where we need to strike.
                    You: Firioris building. Got it.
        */

        static Room room6 = new Room { Name = "Room6", Description = "You've entered an empty ally" };

        /*
                -if Cyber Lens is used-
                    A door appears in front of you at the end of the ally
         */

        static Room room7 = new Room { Name = "Room7", Description = "You continue down the long road" };

        /*
                -if room is inspected so you can see the two guys talking-
                -if you approach the guys-
                    You approach the two men talking with each other. One of them directs the other away, and walks towards you as well. His spiky hair and small jacket stand out.
                    ???: Can I help you?
                    You: No shirt with a jacket three sizes too small. Interesting choice. 
                    ???: In The Crags its hard to find quality clothes, but I wouln't expect you to know that.
                    You: The what?
                    ???: The Crags...you're not from around here are you?
                    You: No, I'm not. My name's {name}, what's yours?
                    ???: ...Drayton. Name's Drayton.
                    You: Sounds bad down in The Crags
                    Drayton: It is. Half the people there are missing a limb or two. It's dangerous down there, but most of its citizens are poor, so they can't afford the replacements the people in these parts get.
                    You: Replacements?
                    Drayton: You don't know? In Uprall, if you're rich enough, you can get missing limbs replaced with cybernetic prosthetics. Whether through medical amputation or grievous injury. 
                    Drayton: Hell, some get replacements by choice. I wouldn't be surprised if at least half the citizens of Uprall are cyborgs by now.
                    You: Wow.
                    Drayton: Yup. Crazy business, huh? Anyway, maybe someday you'd like to check out the lesser side of things. Me and my buddy Zix would be happy to put you up.
                    You: Maybe, if I have time.
                    Drayton: Well, anyway, you'll need this to even have a hope of navigating down there.
                    You got the Hookshot!
                    Drayton: Take care of that, I dont have many.
                    You: Will do.
                    Drayton walks away, leaving you alone with his gift.
                    
                    -if room is inspected so you notice the vendor-
                    -approach the vendor-
                       TJ: Hey there, welcome to my shop. Name's TJ. What would you like?
                        -presented with options-
                            {Prototype Wrist Blasters}
                                -option to buy for 3200 credits-
                                {Yes}
                                    You got the prototype wrist blasters!
                                {No}
                            {Matter Deflection Apparatus}
                                -option to buy for 2900 credits-
                                {Yes}
                                    You Got the matter deflection apparatus!
                                {No}
         */

        static Room room8 = new Room { Name = "Room8", Description = "You enter a shelter" };

        /*
         *      -after inspecting the room and given the option to talk to the gentlemen-
         *          You approach the two gentlemen having a conversation.
         *          Old man: Hello there! Anything I can do for you?
         *          You: Just passing through. Is this your son?
         *          Old man: Oh no, Artem comes by to visit from time to time. He and I just like to talk.
         *          Artem: You don't look like you're from around here.
         *          You: No, I'm not.
         *          Artem, Well, welcome to Uprall! I hope you've been enjoying your time here so far.
         *          You: It's been...interesting.
         *          Old man: Let me give you a bit of advice while you're here: Things are rarely what they seem. It's always good to look at things from a new perspective from time to time.
         *          You: I'll keep that in mind. I gotta go, but it was nice to meet you both.
         * 
         */

        static Room room9 = new Room { Name = "Room9", Description = "You enter what appears to be a courtyard" };

        /*  
                -if cyber lens is NOT in inventory-
                    You: Ah, the Firioris building. This place is huge! Uprall is such a neat place. Maybe tomorrow I'll see that academy.
                    You keep walking through the city, completely oblivious to anything that may or may not be happening in the nation of Uprall.
                    .
                    .
                    .
                    Ending 1: Sightseeing

                
         */

        static Room room10 = new Room { Name = "Room10", Description = "You find your way into an ally" };

        /*
            -when you go north and approach the guard-
            Guard: Can I help you?
            You: Uh, yeah, I'm just trying to get in there.
            Guard: Do you really think I'd just let you walk in?
            You: Maybe?
            Guard: You'd have to pay a pretty penny to get in here pal.
            Pay 750 credits for entry?
            -present options-
                {Yes}
                You: Yeah, here, sure.
                Guard: Heh, well alright. Don't let anybody see you, got it?
                You: Yeah, of course.
                -enter into room 13-
                
                {No}
                You: I don't have the kind of money.
                Guard: Then get lost.
                
                -stay in room-
        */
        
        static Room room11 = new Room { Name = "Room11", Description = "You've reached a dead end" };
        
        /*
        
        -If Hookshot is selected in the inventory while in this room-
            You grapple the roof of a building, allowing you to climb to the top
        
        */

        static Room room12 = new Room { Name = "Room12", Description = "You walked into the Firioris building foyer" };
        
         
        /*
        -This happens if you attempt to go north without having the secret coin in your inventory
        
        You try to enter the elevator door in front you , but...
        You: Ah, nothing's working! There's gotta be some key I need, but I dont have it!
        You ponder for a while what to do next.
        You: That's it, I can't do this, I'm just gonna leave it to Zrkka, and move on with my life.
        You leave the Filioris Building, and Uprall.
        .
        .
        .
        Ending 2: Leave it to the Pros.
        
        
        -This happens if you attempt to go north with the secret coin-
        The private elevator in front of you opens.
        
        -travel to room 15-
        */

        static Room room13 = new Room { Name = "Room13", Description = "You enter a vault" };
        
        /*
        
        -This room cannot be entered from room 12 unless you entered room 12 through this room-
        
        You: Easier than I thought. Ooh, some loot.
        You recieved 1200 credits
        You: I'd call this a net gain.
        You pocket the money, unaware of the camera watching your every move.
        */

        static Room room14 = new Room { Name = "Room14", Description = "You walk into an office" };
        
        /*
        -This room cannot be entered from room 12 unless you entered room 12 through this room-
        
        You: Ok, looks like im in an office. Hey a wallet...with no Id? But there is money!
        You recieved 700 credits
        You pocket the money, unaware of the camera watching your every move.
        */
        
        static Room room15 = new Room { Name = "Room15", Description = "You enter a room" };
       
        /*
        -this event is triggered by using the cyber lens in your inventory-
        
        You see two doors to your right and left
        
        -allows access to west and east directions-
        */

        static Room room16 = new Room { Name = "Room16", Description = "You continue down the hall" };
        
        

        static Room room17 = new Room { Name = "Room17", Description = "You enter the reactor" };

        /*
               You: Ok, the Reactor.
               Almost as soon as you enter, you hear faint explosions. 
               You: Oh yeah, DMN-14 said he was going to going to blow up the reactor and that I shouldn't...go...in there...uh oh.
               Almost on cue, the floor below you erupts in flames as you begin to plummet below.
               
               -The following events trigger if you do NOT have the hookshot in your inventory-
                    -The following event is triggered if you do NOT have the Matter Deflection apparatus in you inventory
                    Without anything to protect you, you dive into the flames, unable to escape. You should've listened better.
                    .
                    .
                    .
                    Bad End: Oops
                    
                    -The following event is triggered if you do havbe the Matter deflection apparatus-
                    Using the Matter deflector apparatus, you manage to protect youself as an explosion launches you back to a safer height.
                    You: That was a close one.
                    DMN-14: Clearly you did not heed my warnings.
                    You: Yeah...my bad.
                    Zrkka: You could've been killed.
                    DMN-14: And yet you are still alive. That means you are still capable of assisting us. 
                    DMN-14: In the coming rooms, you will likely come face to face with Jeanne. Keep an eye out for her.
                    Zrkka: She's dangerous. Very dangerous. Without any enhancmeents, she'll try to either kill you, or cyberize you.
                    You: She sounds charming. I'll be careful
                    
              -The following event is triggered if you DO have the hookshot-
                    You fall into the flames, until you remember you have Drayton's hookshot.
                    You hook yourself to safety, but as you climb, an explosion launches you up. 
                    You feel an extremely sharp pain as you writhe on the floor
                    Zrkka: Holy...sit still, sit still!
                    You: Agh! Zrkka, what the hell happened?
                    Zrkka: I'll be right back, I need to grab something.
                    DMN-14: You have been injured.
                    You: Clearly.
                    DMN-14: You do not understand. This is more than a burn or broken bone.
                    You look down...
                    And notice your left arm has been completely blown off.
                    DMN-14: It would appear that you are in shock, and therefore are numb to the pain. This will not last long, however.
                    Zrkka appears again with a silver prosthetic, which he begins to graft onto you.
                    Zrkka: I'm sure you didn't expect to become a cyborg today, did you?
                    You: This is...way too much.
                    DMN-14: I zympathize with you, {name}, however, it is important that we carry on with our mission. 
                    DMN-14: I am transmitting to your arm some crucial information regarding Uprall. 
                    DMN-14: I belive it wil lassist you, should you need to take the competance assessment.
                    Zrkka: But beyond that, you'll probably come across Jeanne's torture chamber. And with that arm, she just might find use for you.
                    You: Is that bad?
                    Zrkka and DMN-14 laugh for a moment
                    Zrkka: Very.
                    DMN-14: Pray you find a way past her.
                    You: I see. Thanks guys...not concerning at all.
                    
                    -after this event, you are moved to room 16 and cannot reenter, if you try:-
                    You cannot enter the reactor
                   
        */
        
        static Room room18 = new Room { Name = "Room18", Description = "You walk into a large room" };
        
        /*
                -This prompt will occur every time you enter the room, unless Jeanne's Key is in your inventory-
                No matter where you look, you can't seem to find any way forward. Do you wish to give up?
                
                -present choices-
                    {Yes}
                        You: I've done way to much for these guys. I've put myself in so much danger, and I'm no closer to finishing this. 
                        You: That's it, I'm done, they can do this themselves.
                        .
                        .
                        .
                        Ending 3: I'm out
                   {No}
                   
                -prompt when cyber lens is used-
                    You see a door in front of you. 
                    A password is required
                    
                    -allow the player to type in a password-
                    
                    -if password is wrong-
                    Incorrect
                    
                    -if password is correct-
                    Correct.
                    Please provide member authentication
                    
                    -player must use the official intiate badge in their inventory-
                    
                    To access this area, you must be a high ranking member. Please provide Identification.
                    
                    -player must use Jeanne's Key in their inventory-
                    
                    Welcome, Jeanne. High-rank Key must be provided
                    
                    -player must use secret coin in their inventory-
                    
                    Thank you, you may enter the elevator.
                    
                    -allows player to go north-
                    
                    
        
        */
        

        static Room room19 = new Room { Name = "Room19", Description = "You've made it to the Sanctum" };
        
        /*
        
        As you walk forward, you see a large table with five figure sitting at it. Here they are, the Cyber Directors
        .
        .
        .
        Directive Head 1: We've been waiting for you, {name}
        You: How do you know my name?
        The second director gestures to a wall of monitors
        Directive head 2: We've been watching your every move.
        Your heart drops as you notice Cyclone step out of the shadows
        Cyclone: Hello again. {name}, was it? I need to make sure the get the name on your tombstone right.
        Directive Head 1: Now, now, cyclone. Settle down. We wouldn't want our guest here to be frightened now, would we?
        You feel your heartbeat quicken. Zrkka should know where you are, why hasn't he shown up yet?
        Director 3: We'll give you a choice, {name}, you either leave now, and forget all of this happened, or you can stay, and die a pointless death.
        .
        .
        .
        What will you do?
        -present choice-
            {Leave}
                You: Look, you're right. I'm in way over my head, I'm going to leave.
                As you turn around and walk away, you feel some relief at the fact that you are leaving alive.
                A shame you couldn't hear Cyclone lifting his daggers.
                .
                .
                .
                Bad End: Silenced
                
            {Stay}
                You: I've come to far to bail out now.
                Directive Head 4: You are quite foolish.
                Directive Head 5: Jeanne, if you would.
                From behind you, you hear the elevator open, and feel something wrap around you, holding you in place.
                Jeanne: I would like my key back now.
                Directive Head 2: It is truly a shame, but you must understand, you are a nuisance that must be eradicated.
                Directive Head 1: Goodbye, {name}.
                .
                .
                .
                Almost as if by fate, you hear gunfire and explosions coming from down below.
                Soon after, Zrkka and DMN-14 break into the sanctum, and without any words, attack Jeanne and Cyclone.
                Directive Head 3: We must leave! cyclone, Jeanne, eliminate them!
                With that, the directive heads use teleportation technology to leave the area. 
                Zrkka: Get to safety! We got this!
                You: Are you-
                Zrkka: Go! Now!
                So you run.
                .
                .
                .
                You exit the filioris building and enter its courtyard, and eventually see Zrkka and DMN-14 leap out of an upper floor window and crash into the ground.
                You run to help them.
                You: Are you guys ok?
                Zrkka: I'm fine, 14?
                DMN-14: Superficial damage. No system errors detected.
                You: That's a relief. so, what happens now?
                Zrkka: Well, we stopped their operations in this area at least. But Uprall's a big place. They've gotta have another front somewhere. 
                You: Well, then we gotta stop them.
                DMN-14: 'We'?
                You: Yeah, like you said, I'm in it now.
                Zrkka smiled at this.
                Zrkka: That you are. Alright then, welcome to the team....
                .
                .
                .
                True End: Conspiricy Theorist
                
        
        */

        static Room room1001 = new Room { Name = "S-Room1", Description = "Wow, a casino!" };
        
        /*
                You: Hey, this place has blackjack! Maybe I can have some fun.
                Dealer Viall: Welcome to the Casino. My Name is Viall, and I'll be your dealer this afternoon.
                
                -initialize blackjack game-
                -when player leaves-
                
                Dealer Viall: Thank you for playing, feel free to stop by anytime.
                
                -if player at ANY point has less than 0 credits-
                
                Dealer Viall: Ooh, that's unfortunate. It looks like you still owe, and without the funds, we'll have to make due with your limbs and organs. Brace yourself, cuz this will hurt.
                You: Wait, wha-
                Maybe next time you'll be careful when you gamble.
                .
                .
                .
                Bad End: The House Always Wins
        */

        static Room room1002 = new Room { Name = "S-Room2", Description = "You grappled to the rooftop" };

        /*
        meeting with DMN
        */
        
        
        static Room room1003 = new Room { Name = "S-Room3", Description = "Wow, a casino!" };
        
         /*     You: Hey, this place has blackjack! Maybe I can have some fun, I'm sure Zrkka won't mind.
                Dealer Viall: Welcome to the Casino. My Name is Viall, and I'll be your dealer this evening.
                
                -initialize blackjack game-
                -when player leaves-
                
                Dealer Viall: Thank you for playing, feel free to stop by anytime.
                
                -if player at ANY point has less than 0 credits-
                
                Dealer Viall: Ooh, that's unfortunate. It looks like you still owe, and without the funds, we'll have to make due with your limbs and organs. Brace yourself, cuz this will hurt.
                You: Wait, wha-
                Maybe next time you'll be careful when you gamble.
                .
                .
                .
                Bad End: The House Always Wins
        */

        static Room room1004 = new Room { Name = "S-Room4", Description = "You enter another hallway" };
        /*
        -going north prompts you for the password-
        -if password 'freewill' is entered, you go to S-Room5, must be entered every time you wish to go to the room-
        -if password is not entered, player cannot enter to the room-
        */
        
        static Room room1005 = new Room { Name = "S-Room5", Description = "You enter a dimly lit room" };
        
        /*
        -after inspecting the room, you get Jeanne's document-
        */
        
        static Room room1006 = new Room { Name = "S-Room5", Description = "You enter what appears to be a torture chamber" };

        
        static Room room1007 = new Room { Name = "S-Room6", Description = "You find what appears to be a testing facility." };

        
        static Room room1008 = new Room { Name = "S-Room7", Description = "You walk into an elevator" };
        
        /*
        You: Ok, this is it. Endgame time. I can only go forward...or back...
        If you go back, you will fail to finish your quest, but you will escape with your life
        
        -present choice-
            {Go Back}
            You: No, no, no, I can't do this. I'm not capable of this! I can't do this, I can't! I'm sorry Zrkka, but I can't do this!.
            .
            .
            .
            Ending 5: Overwhelmed
            
            {Press on}
            You: No, I've come to far to turn back now. Let's do this!
            The elevator doors opens...
            -enter room 19-

        */
        
   /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     
        /*
            -occurs the first time a player has more than 1000 credits Will not prompt anymore after this one instance-
            You: This is a lot of money I've got here, should I just cut my losses and leave?
            
            -present choices-
                {Yes}
                    You: Ah, whatever happens here happens. I'm outta here!
                    Ending 6: I'm rich!
                {No}
                    You: Nah, I'm not done here in Uprall yet.
        */
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////
   
        
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////    
        
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////         
        
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////           
        
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////   

        static Room currentRoom = room1;

        



            

            // GET YES/NO OR Y/N RESPONSE. RETURN TRUE FOR YES/Y, FALSE FOR NO/N
        static bool GetYesNo(string prompt)
        {
            string[] valid = { "YES", "Y", "NO", "N" };
            string ans;
            ans = GetString(prompt, valid, "?Invalid response, please reenter");
            return (ans == "YES" || ans == "Y");
        }

        // UNIVERSAL GET STRING WITH PROMPT, VALID VALUES, AND ERROR MESSAGE
        static string GetString(string prompt, string[] valid, string error)
        {
            // prompt=user prompt, valid=array of valid responses, error=msg to display on invalid entry
            // ALL STRINGS RETURNED UPPER CASE. ALL valid[] ENTRIES MUST BE IN UPPER CASE
            string response;
            bool OK = false;
            do
            {
                Console.Write(prompt);
                response = Console.ReadLine().ToUpper();
                foreach (string s in valid) if (response == s.ToUpper()) OK = true;
                if (!OK) Console.WriteLine(error);
            } while (!OK);
            return response;
        }

        class Room //Room being created as a class
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }

        internal static class Directions //Directions being declared as a class
        {
            public enum Direction
            {
                North,
                South,
                East,
                West,
                NorthEast,
                SouthEast,
                NorthWest,
                SouthWest,
                NE,
                NW,
                SE,
                SW,
                N,
                S,
                E,
                W
            }

            public static Direction GetDirection(string input) //Functions to get directions being created
            {
                switch (input.ToLower())
                {
                    case "north":
                        return Direction.North;
                    case "south":
                        return Direction.South;
                    case "east":
                        return Direction.East;
                    case "west":
                        return Direction.West;
                    case "northeast":
                        return Direction.NorthEast;
                    case "southeast":
                        return Direction.SouthEast;
                    case "northwest":
                        return Direction.NorthWest;
                    case "southwest":
                        return Direction.SouthWest;
                    case "n":
                        return Direction.North;
                    case "s":
                        return Direction.South;
                    case "e":
                        return Direction.East;
                    case "w":
                        return Direction.West;
                    case "ne":
                        return Direction.NorthEast;
                    case "se":
                        return Direction.SouthEast;
                    case "nw":
                        return Direction.NorthWest;
                    case "sw":
                        return Direction.SouthWest;
                    default:
                        Console.WriteLine("Invalid input. Please enter a valid direction.");
                        string newInput = Console.ReadLine();
                        return GetDirection(newInput);
                }
            }

        }
    }
}  
