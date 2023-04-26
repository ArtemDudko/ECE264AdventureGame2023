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
        public static Dictionary<int, bool> LoadTriggers(string root_folder)
        {
            //load Rooms.txt and process
            
            string raw_trigger_data = File.ReadAllText(root_folder + "\\Triggers.txt");
            raw_trigger_data = raw_trigger_data.Remove(0, raw_trigger_data.IndexOf("&&&") + 3);      //remove unnecessary stuff
            StringBuilder sb = new StringBuilder(raw_trigger_data);
            sb = sb.Replace("\n", "");
            sb = sb.Replace("\t", "");
            sb = sb.Replace("\r", "");
            var raw_trigger_data_array = sb.ToString().Split('&');
            var trigger_data_dic = new Dictionary<int, bool>() { };
            for (int trigger_id = 1; trigger_id < raw_trigger_data_array.Length / 2; trigger_id++)
            {
                trigger_data_dic.Add(trigger_id, bool.Parse(raw_trigger_data_array[trigger_id * 2 - 1]));
            }
            return trigger_data_dic;

        }


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
            .
            .
            .
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
                .
                .
                .
                Zrkka: Here, take this. It'll help you see things in Uprall that they don't want you to see. It'll come in handy, I'm sure.
                You recieved the Cyber Lens!
                Zrkka: A friend of mine is patrolling the city as well. It's likely you'll run into him. He'll need your trust, or else he'll kill you. 
                You: That's comforting. How do I get his trust?
                Zrkka: He'll ask you a question, you give him the answer. The answer is '112'.
                You: 112. Got It. How will I know this friend of yours.
                Zrkka: Oh, you'll know. His bite is a lot worse than his bark.
                With a chuckle, Zrkka leaves the ally by jumping over a large gate.
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
        You leave the Firioris Building, and Uprall.
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
                    DMN-14: I sympathize with you, {name}, however, it is important that we carry on with our mission. 
                    DMN-14: I am transmitting to your arm some crucial information regarding Uprall. 
                    DMN-14: I belive it will assist you, should you need to take the competance assessment.
                    Zrkka: But beyond that, you'll probably come across Jeanne's torture chamber. And with that arm, she just might find use for you.
                    You: Is that bad?
                    Zrkka and DMN-14 laugh for a moment
                    Zrkka: Very.
                    DMN-14: Pray you find a way past her.
                    You: I see. Thanks guys...not concerning at all.
                    
                    You Got the Cyber Arm!
                    You Got the Uprall Informational Data!
                    
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
                   
                   -Prompt When Hookshit is used-
                   You use the grappling hook to grab onto a railing at the end of the gap. You should be able to get over there now
                   -allow access to S-Room7-
                   
                -prompt when cyber lens is used-
                    You see a door in front of you, and to your left. 
                    
                    -allows access to S-room6 and 8
                    
                    
                    
                    -if player tries to go west-
                     A password is required
                    
                    -allow the player to type in a password-
                    
                    -if password is wrong-
                    Incorrect
                    
                    -if password is correct-
                    Correct.
                    
                    -plsyer enters S-Room6-
                    
                    
                    
                    -if player then tries to go north-
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
                You exit the firioris building and enter its courtyard, and eventually see Zrkka and DMN-14 leap out of an upper floor window and crash into the ground.
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
        You walk forward and see a robot dog. It takes notice and turns toward you.
        .
        .
        .
        ???: Halt.
        You stop walking as soon as you notice a large machine gun mounted on its back.
        ???: I am giving you one chance only; State your business, or leave.
        -Present choices-
            {Leave}
            You: Ok, I'm going.
            -you go back to room 11 and can no longer access this room-
            
        {Stay}
        You: Uh, my name is {name}. I was sent here by Zrkka.
        The dog aims the gun at you.
        ???: If this is true, then he would have given you the answer to this question:
        .
        .
        .
        ???: On our first mission to The Red Stone, it was far hotter than either of us had experienced before. What was the temperature reading in degrees?
        
        -player types in their response, only numbers will be allowed-
            -if player does NOT type in 112-
                ???: Incorrect. I cannot allow any chances. I am sorry. You must die.
                Before you can even get a word out, he lets out a barrage of shots. You collapse immediately.
                .
                .
                .
                Bad End: No chances
            -if player DOES type in 112-
                ???: Correct. You appear trustworthy. I am DMN-14. It is a pleasure to meet you.
                Your heart is still beating from having a gun pointed at you.
                You:...pleasure's all mine.
                Zrkka: I see you've two met.
                DMN-14: Zrkka. Welcome back. I trust your scouting mission was successful?
                Zrkka: Yup, got some nice intel. However, since they'll be looking for me, I'll need you to infiltrate my friend.
                You: Me?
                DMN-14: Hmm. It would be the safest and wisest course of action. In the event you are caught, you can always play coy and act like you dont know anything.
                You: So it'd be the truth.
                DMN-14: While humor has its purposes, this is not one of them.
                .
                .
                .
                DMN-14: Some rooms will be password protected. to open them, you must use the phrase 'freewill'. It is an ironic name considering the directive's goals.
                You: Yeah...so, that building there?
                DMN-14: Correct. You will go in through this offcie building. Zrkka and I will assault the reactor, leading any unsavory personel away from you.
                DMN-14: I would not recommend going enar the reactor.
                You: Yep yep, got it. Ok, let's go, i guess.
                You Got the Password!
                -player enters room 14 automatically-
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
        You got Jeanne's Document
        */
        
        static Room room1006 = new Room { Name = "S-Room5", Description = "You enter what appears to be a torture chamber" };

        /*
        You walk a few steps before you are face to face with a menacing looking woman. She doesn't look like a cyborg, but you can tell that she is.
        
        -this event triggers if you enter the room WITHOUT the cyber arm-
        ???: You are not a cyborg. 
        You: No, I am not. You must be Jeanne.
        Jeanne: It appears I have a fan.
        You: Not really, if not for Zrkka, I wouldn't even know who you are.
        Jeanne: You are with Zrkka? Hahahaha, ahh, c'est magnifique! It will be fun breaking you.
        
        -the following event is triggered if the prototype wrist blasters are NOT in your inventory-
        Jeanne attacks you, and there is no way for you to fight back.
        She tortured you for what seemed like days. When she was finally convinced you didn't know anything, she left you for dead, your will finally broken.
        .
        .
        .
        Bad End: Broken will
        
        -The following event is triggered if the wrist blasters ARE in your inventory-
        Jeanne attacked you, but thanks to your wrist blasters, you were able to fight her off. 
        You take Jeanne's key off her unconscious body, and book it out of there before she had a chance to wake up.
        You got Jeanne's Key!
        
        -this event triggers if you enter the room WITH the cyber arm-
        ???: A cyborg? Are you a lost new recruit? Who are you?
        -present choices-
            {I'm here to stop you}
                You: I'm here to put a stop to whatever you're doing, Jeanne!
                Jeanne: You know my name? You must be with Zrkka! I will break you.
                Jeanne grabbed her spear and ran straight at you
                
                -this event triggered if you do NOT have the prototype wrist blasters-
                You knew almost immediately that was a mistake. The spear drove it home.
                .
                .
                .
                Bad End: Big Mistake
                
                -this event is triggered if you DO have the wrist blasters-
                You try to fight Jeanne off with the wrist blasters you bought earlier, and you put up quite a fight. Jeanne had to call for reinforcements to assist her.
                At that moment, you come up with an idea; you can distract all of the guards, so Zrkka and DMN-14 can accomplish their mission.
                You run out of the room, and blast your way past everyone that comes your way.
                .
                .
                .
                Ending 4: Gung-ho
            {I'm here to serve the directive}
                You: I am here to serve the directive, lady Jeanne.
                Jeanne: I see. Then I suppose you have been briefed on everything you need to know. Let's test that then, hm?
                .
                .
                .
                Jeanne: I am among the top enforcers in the directive, but there is one who is considered my superior. What is his name?
                    -present choices-
                        {Voris- The Superior Cyborg} //<-- correct
                        {Cyclone- The Cyber Storm}
                        {Aurelius- the Dying Shadow}
                        
                Jeanne: We recently had an escapee, tenacious little thing. What was her name?
                    -present choices-
                        {Marina}
                        {Frolic}
                        {Celia} //<-- correct
                        
                Jeanne: The traitor and his pet lap dog. Surely you've heard of them. What are their names?
                    -present choices-
                        {Mirio and Marina- The Reason Within Madness and The Star of Cindren}
                        {Zrkka and DMN-14- The Steel Reaper and The Gun Wolf} //<-- correct
                        {A'sher and Morris- The Savior King and The Heir of Shinaran}
                        
               -This event triggers if at any point the players gets a SINGLE question wrong-
               You feel something grab at you, holding you in place.
               Jeanne: Wrong! I knew you were with Zrkka. 
               You struggle to get free, which only makes Jeanne laugh.
               Jeanne: You said you were here to serve the directive? Then that's exactly what you'll do.
               All you can do is scream as she takes you away. 
               .
               .
               .
               Soon all that remains of you is the cybernetic husk used to control your consciousness. 
               Your first mission as the newest directive initiate; eliminate Zrrka, The Steel Reaper.
               You will fail and die, of course, but at least they can make an example out of you.
               .
               .
               .
               Bad End: Eternal Service
               
               -this event triggers if the player gets all question right-
               Jeanne: Well done. I suppose I can trust you. I have some important information to give to the directors. 
               Jeanne: However, I am a bit busy, so I will give you this key for you to access the elevator. 
               You Got Jeanne's Key!
               Jeanne: Now run along.
               
               -player exits to room 18 and can NOT reenter-

        
        
        */
        
        static Room room1007 = new Room { Name = "S-Room6", Description = "You find what appears to be a testing facility." };

        /*
        -This event only plays on the first visit-
        
        You enter a chamber and see a young cyborg about to enter a room. He waves at you.
        Nik: Hey there buddy. Name's Nik, how are you?
        You: {name}. Im doing well, thanks.
        Nik: You here for the test too?
        You: Uh, yeah. For sure.
        Nik: I'm sure you'll do great. Anyway, I'm up, nice to meet a new recruit!
        You: Yeah, you as well.
        .
        .
        .
        You enter the test room
        PA: Welcome. To ensure that we let quality members into our directive, it is important we test your knowledge, so as to not allow lesser beings into the directive.
        You: 'Lesser beings'? Sheesh..
        .
        .
        .
        PA: Question 1: What is the Capital of Uprall?
            -present choices-
            {Morico City}
            {Helio City} //<--- correct answer
            {Kiro City}
            .
            .
            .
        PA: Question 2: Which nations border Uprall?
            -present choices-
            {Shinaran}
            {Cindren and Beleran}
            {Beleran and Sakanata} //<-- correct
            .
            .
            .
        PA: Question 3: What is the percentage of cybernetic citizens in Uprall?
            -present choices-
            {47%}
            {52%} //<-- correct
            {88%}
            .
            .
            .
        PA: Question 4: What is the name of this building that you are taking this test in?
            {Firioris} //<-- correct
            {Murcurius}
            {Helio}
            .
            .
            .
        PA: Final Question: Who is the official body of leadership in Uprall?
            -present choices-
            {A President}
            {A Dictator}
            {A Council} //<-- correct
            .
            .
            .
        PA: Caluclating score, please wait...
        .
        .
        .
        PA: Your score is {score}       //score is determined by however many answers correct, 20% for each correct answer
        
        -triggered if player score is < 60-
        PA: We are sorry, but we cannot allow lesser beings such as yourself inside our directive. Or inside society. We will purge you now. Goodbye.
        You: Whoa whoa, wai-
        .
        .
        .
        Bad End: Incomptetance.
        
        -triggered if player score is >= 60-
        PA: Well done, you have passed. Here is your Official Initiate Badge. Now please vacate the room for the next initiate.
        You got the Official Initiate Badge!
       
        */
        
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
   /*
   -Selecting 'Password" in inventory shows this text-
   The password for the Firioris building DMN-14 gave you; 'freewill'
   */
        
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////    
   /*
   -Selecting "Uprall Informational Data" in inventory-
   Uprall is a nation laying on the borders of Beleran and Sakanata. The Uprallan Council govern the nation from the cpital of Helio city. 
   Uprall is the most technilogically advanced place in the world, sporting a 52% cyborg rate for its citizens. Whiel you're here, enjoy the bright 
   lights, the funky tunes, and most importantly, enjoy the future.
   */
        
        
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////         
  /*
  -selecting Jeanne's document-
  This is not good. Voris will be expecting a report soon. That little brat, Celia, somehow the only one to manage to escape this place. Escape me. 
  I don't know how she did it. But I wouldn't be surprised if she went running to that traitor Zrkka, and his pet. That DMN unit, number 14 I think?
  */
      
  /////////////////////////////////     /////////////////////////////////     /////////////////////////////////     /////////////////////////////////           
  /*
  -if you at any point use the cyber lens while the coin is in your inventory-
  You find some strange markings on the coin, you decide it might be worth something.
  The Coin turned into The Secret Coin!
  */
        
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
