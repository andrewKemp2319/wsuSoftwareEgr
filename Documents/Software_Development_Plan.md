#### Fall 2022 CEG-4110-10 CEG-6110-10

#### Introduction to Software Engineering

#### Class Project Overview

### Project Title: 
Rogue-like Video Game

### Team Name: 
I Got Nothing 

### Team Members:
Nash Infanto <br>
Andrew Johnston <br>
John Steimle <br>
Andrew Kemp <br>
Ethan Heinlein <br>
Joy Fisherback<br>
Abram Agee <br>


### Project Synopsis: 
To build and create a video game that will be in the genre of rogue-like game.

### Concept of Operations (CONOPS):
A rogue-like video game is a dungeon crawling game that allows the player to proceed through various levels obtaining random gear to increase their power strength. As the player adventures further through the levels the enemies will become stronger and increase in number. The game will continue until the player defeats the final boss or the player dies. Once this happens the player will lose their character and must start a new character to play again. A new adventure will offer a different play style since the itemsdropped to the player will not always be the same as the last adventure.

### Software Development Environment:
* Hardware: Non-hardware specific
* Operating System: Non-OS specific
* Compiler/Linker Tools:
  * C# .NET SDK v6
  * Godot v4.1.1
  * GitHub
  * Doxygen

### Configuration Management:
* GitHub
* Documents will be configured upon initial development and any later updates.
    * Track requirements such as product backlogs or user stories.
* Software is configured upon initial development and passing tests.
    * Merges only occur when agreed on by multiple team members.
  
### Target Environment:
<li>Hardware: Non-hardware specific computer but will run more optimal with better components in computer.</li>
<li>Operating System: Windows.</li>
<li>The program will be ran in C#.</li>
<li>A goal is to develop a software that will allow the user to play a video game without skipping frames or input delay.</li>

### Development Methodology:
<li>Agile</li>
<li>Using Email and Discord to communicate while we’re not in class or not able to meet outside of class</li>
<li>Outside of Email and Discord we will also be using GitHub to track what is being submitted and what parts of the 
project is needed to focus on. It will also keep a log of who in the team is submitting what.</li>
<li>A design document will be used in the development of the key design decisions and will track when major decision changes are made.</li>
<li>Doxygen will also be used to document the code and make sure the requirements are being met.</li>

### Requirements:
- Requirements are being tracked using a combination of Github Issues and the "Milestone" feature, where you can group a series of issues together under a larger label (MVP for example). Several of these may be created to accomodate the various features/user stories/bugs.
- Tracking completion can be done through this, as you can view a milestone's progress (0-100%). Updates can be handled by updating the issue directly, or creating another issue related to the initial one.
- Evidence can be found in the Issue, where different stats such as when the issue was closed, who it was assigned to, and who took part in reviews can be found. Issues can also have comments for additional recordkeeping as needed.

### Documentation/Traceability:
<li>For documentation we are using user story to plan out and require every group memeber to document what they are doing and what their plan are for the future</li>
<li>Requiring documents with every file that state the idea of the code and what it does.</li>
<li>Using Product Backlogs will be utilized to prioritized and create a timeline for every member of the team.</li>
<li>Meeting minutes will be used to create a coherent document on what has been done by every team member and what is needed from them in the future.</li>
<li>Creating goals for each member and requiring them to be updated every week and what they have completed in said week and what they didn't complete.</li>
<li>Using comments in code and using Doxygen will allow each team member to understand what the code is doing and what has been worked on and what needs to be added to the code.</li>
<li>Every Quality Assurance member will be responable to go over their own code and to go over others code to make sure everyone understands what the code does.</li>
<li>Going over Code each week and during meeting minutes if needed will allow the code to be coherent and only what code is needed for the program.</li>
<li>Design Evidence will be kept in a folder in GitHub that is labeled "As Bulit Design"</li>

### Code Coverage:
<li>Function Coverage - percentage of the functions that the tests call</li>
<li>Line Coverage - percentage of lines that the tests execute</li>
<li>Branch Coverage- percentage of branches that are executed at least once</li>
<li>Statement Coverage- number of statements executed when the code is running.</li>

Code Coverage resuts will be stored on the Documents branch.

### Design:
<li>The code's functionality will be documented using Doxygen.</li>
<li>Additionally, the as-built design specifications will be recorded in a separate document (https://github.com/WSU-DGscheidle/fall-2023-team01_i_got_nothing/blob/Documents/As%20Built%20Specification) as features are finished.</li>
<li>Doxygen will run at the end of each sprint to update the code documentation.</li>
<li>Each pull request must be reviewed and approved by at least one other developer. If a reviewer finds problems with the request, they must be addressed before the code is merged.</li>

### Identify Roles: 
<li> Team Members: Nash Infanto, Andrew Johnston, John Steimle, Andrew Kemp, Ethan Heinlein, Joy Fisherback, Abram Agee </li>
<li> Project Manager: Ethan Heinlein </li>
<li> Functional Manager: Abram Agee </li>
<li> Team Manager: Andrew Kemp </li>
<li> Developers: Nash Infanto, Andrew Johnston, John Steimle, Andrew Kemp, Ethan Heinlein, Joy Fisherback, Abram Agee </li>
<li> Scrum Master: Andrew Johnston </li>
<li> Quality Assurance: Nash Infanto, Andrew Johnston, John Steimle, Andrew Kemp, Ethan Heinlein, Joy Fisherback, Abram Agee </li>

### Schedule:
<li> First Day of Class: Tuesday 8/29/2023.</li>
<li> Teams Formed: Thursday 9/7/2023. </li>
<li> Project start date: Tuesday 9/26/2023.</li>
<li> Identified project: Tuesday 9/19/2023.</li>
<li> Project overview: Tuesday 9/19/2023.</li>
<li> Sprint durations: 2 Weeks starting 9/28/2023.</li>
<li> Project end date: 12/3/2023.</li>
<li> Sprint starts:</li>
<ul> 
<li> 10/12/2023</li> 
<li> 10/26/2023</li> 
<li> 11/9/2023</li> 
<li> 11/23/2023</li></ul>

### Identify the Product Backlog:
> Each of the following are “high-level” features that may consist of more sub-points to be defined as the project evolves.

- The player must be able to move a digital character using at least one computer input device
- The player must be able to wield a weapon that can defeat enemies, using a computer input device
- The player shall have different evasive options to avoid enemy projectiles, such as a dash or jump
- A level must be generated at various points throughout the game that the player and enemies can traverse.
- Enemies must traverse the level and shoot projectiles at the player
- Enemies shoot projectiles in different patterns, depending on enemy visual theme
- Enemies increase in difficulty (more complex projectile patterns, higher stats, visual changes) as levels progress
- Entities will have different statistics that determine how they respond to the world, including:
  - Health, the direct number of hits an entity can take before dying
  - Attack, the amount of damage entities do to each other with their attacks
  - Speed (Godot units), how fast an entity moves across a level
- The player will be able to collect items that either change the statistics listed above, or alters their input options (a new weapon, an evasive option gets better).

Terms:
- Player: A collective term for the end user and their character during gameplay
- Entity: A collective term for the player and enemies

### Identify Initial Sprint Backlog
1. Player character inputs (movement, evasive options, basic weapon controls)
2. Basic enemy implementation
3. Enemy projectile pattern system
4. Implementation of stats system
5. Enemy and Player death events
6. Basic level generation
7. Item system (collection, state upgrade, generation)
8. Weapon system

### Sprint Execution
#### Sprint Planning
Inputs:
- Product backlog
- Sprint backlog
- Any required technical information

Team Activity:
- Product Owner: Updates product backlog to contain updated requirements
- Scrum Master: Works with the team and product owner to define the new sprint backlog
- Development Team: Provides feedback on task efforts and sprint backlog.
- All team members define what "Done" is.

Outputs:
- Refined product backlog
- Updated sprint backlog

#### Daily Scrum:
Inputs:
- Sprint backlog

Team Activity:
- Scrum Master: Polls the team as to the status of the project
- Development Team: Provides status on progress and other needs

Outputs:
- Updated sprint backlog
- Meeting minutes

#### Sprint Review
Inputs:
- Sprint backlog

Team Activity:
- Sprint review
- Stakeholders updated with latest status

Outputs:
- Delivered new software capability (increment)

### Commit Requirements:
A commit requires the following info:
- Issue number(s) the commit addresses (if applicable)
  - Generally, commits should only address 1 issue though, unless the two issues are related.
- A short message (<50 chars) describing why the changes were made (why instead of how)
- Commits should be made in an appropriate feature branch (for large features) or to the "develop" branch directly (bug fixes, hotfixes).

#### For Merge Requests:
- In addition to the above, merge requests will need an assigned reviewer to approve or cancel the merge,
and provide feedback as needed.

### Minutes:
Meeting minutes are small documents detailing the following about a given meeting:
- Agenda (items to address)
- Attendees
- Accomplishments of the attendees
- Action items for each team member

Minutes are stored on our group Discord server, but will be moved to the "Documents" branch under a Meeting Minutes folder.

### Review Information:
The following items will be reviewed:
- Requirements fulfilled (if any)
- Design of solution
- Code of solution
- Correct/Appropriate use of Doxygen-compatible commentssUser stories distributed into tasks to be completed

### Actions:
Action items are recorded in each Meeting Minutes document. Additionally, Github Issues have been created to document each feature or bug that we can track through branch names, the issue itself, and merge requests. Evidence can be found in both Github and through our Meeting Minutes.

Team Signitures
Ethan Heinlein
Andrew Kemp
Joy Fisherback
John Steimle
Nash Infanto
Abram Agee
Andrew Johnston
