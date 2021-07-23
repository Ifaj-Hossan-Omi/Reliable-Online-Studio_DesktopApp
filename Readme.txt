Project Details:
-----------------

There are five forms in this application. 3 of them are user forms(Client, Photographer, Staff)
and remaining 2 of are for login and sign up. Apart from the main task, rest of the actions are
handled through user control. There are some user controls which have been universally used
for all forms. Rest of the user control has been only for dedicated tasks.
Threading has been used while switching between forms. Threading permanently closes the
previous from when switching to another form.

User Interface :
-----------------

After the program starts, the user will see the login option. If the user does not have an account
then he/she can create an account from the same form.

Account Creation:
------------------

There are two types of accounts that a user can create. 1. Photographer 2. Client
User will select any one of the buttons and the sign up form will come up. Account creation
process is similar for both. If the user decides to create a photographer account then the user's
information will be saved in the photogapherInfo table of the database. Client account
information will be saved in the clientInfo table of the database.

Sign In:
---------

Users can log in to the system by giving their name and password. Every type of user can login
using this single login form. System will go through all the tables of photographer, client , staff in
the database and check if there is any matching user. Then the login form will be closed and the
user will be taken to a form according to the user type(client/photographer/staff). Also the user’s
name will be parsed in the form.

Photographer’s Interface:
-------------------------

When a photographer signs into the system the user will see a few menu options on the
sidebar.

    1. Portfolio:
   ---------------
    Photographers can see and update their personal information here. Because
    this user control is used by all users, base form will pass username and tablename as
    attributes and user control will show or update profile using the provided tableName by
    searching the username.

    2. Orders:
   -----------
    This user control will use the username to show the task to the photographer
    from the tasktable. The tasks will be shown in a data grid view and the photographer can
    accept or deny tasks from this form.

    3. Progress:
   -------------
    Username will be used and the photographer will be shown his rating and
    growth rate on this form.

    4. All Task:
   -------------
    Username will be used to find all the tasks that the user received.
    Photographers will then be shown all their tasks in this form.

    5. Deliver:
   ------------
    All the tasks that the photographer received will be brought to the datagrid view
    using username. From there the photographer will be able to select a task for delivery.
    From that list the photographer will select the task that he wants to deliver. This data will
    be saved in the table and the task status will go to delivered.

    6. Report:
   -----------
    Since this form can be used by all users, here username and table will be used
    as attributes. User will first enter the name of the complainee and write his complaint. If
    the user clicks on submit then it will be stored in the table. Also the user can see all the
    previous complaints and staff reply to all those complaints by clicking the previous
    button.

    7. Delete account:
   --------------------    
    Username and tablename will be taken and searched in the specific
    table. Then the account information will be deleted and close the form and then the login
    form will appear.

    8. Exit :
   ----------
    If the user clicks the exit sign then the current form will be closed and another
    instance of login form will be opened.

Client Interface:
-----------------

    1. Profile :
   --------------
    Profile is similar to the portfolio of a photographer.

    2. Order:
   ----------
    In this section user control will show all the photographer information in a data
    grid view. Client can select photographer for ordering and after selecting, the client has
    to write the order details and attach a photo or the client can decide to cancel the order.
    This user control saves the order details in the task table with respect to the client
    username.

    3. All order:
   --------------
    Every order given by the user will be shown as a grid view on the table using
    the username. The user can see the task status on this order.

    4. Delivered Order:
   --------------------
    Here the client will be able to see the tasks which have been delivered
    to him from various photographers. The client can select them from the data grid view
    and give feedback rating to the photographer. All this data will be saved in the task table
    using the username.

    5. Report:
   -----------
    The user can report to the staff through this menu about any unpleasant
    experience that happened in the app.

    6. Delete Account:
   -------------------   
    The client can delete their account through a process similar to all other
    users.

    7. Exit:
   ---------
    Exits to the login form (same or all users).

Staff Form :
------------

    1. Profile:
   ------------
    Shows similar information as other users.

    2. Create:
   ------------
    This appears as a sign up form. By passing staffInfo tablename, one staff can
    create another staff by filling the details and saving them in a staff table.

    3. Photographer:
   -----------------
    Show all photographer details in data grid view from database using the
    photographerInfo table.

    4. Client:
   ------------
    Show all client details in data grid view from database using clientInfo table.

    5. Manage Complaint:
   ----------------------
    All the complaints which were not replied to or denied appear in a
    data grid view from the complaint table from the database. Staff can select the complaint
    and reply to them and take action or deny. The data will also be saved in the complaint
    table in the database.

    7. Exit:
   ---------
    Exits to the login form (same or all user


Software:
----------
	
	* Visual Studio 2019 (IDE)
	* Microsoft SQL Server 2014 (Database)
	* Microsoft SQL Server Management Studio
	* GunaUI2 (Button, Textbox and others)
	* BunifuUI (Gradient Panel)
	* Canva (GIF and Pictures)
	* Pichon (Icons)
	* Just Color Picker


Login credentials:
------------------

Photographers and clients can access the application through signing up. Also two credentials of photographer and client is given below.

Photographer:
-------------
Username: alex
Password: 123

Client:
-------
Username: justine
Password: 123

Since staff account cannot be created from the log in form. Login credentials for a staff is given below.

Staff:
-------
Username: staff
Password: 123


