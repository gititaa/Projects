Set ContactsManager as startup project
In ContactsManager - Web.Config change 'Data Source' name for connectionstrings 'DefaultConnection' and 'ContactConnection'. It should be SQL instance name.
Run the project.
Browse Default.html
Register user, 'user created' alert is displayed if user is created successfully. (please enter email and password, password should be like Password-2)
Use email id and password used in register user to login.
After hitting login button you will be redirected to Contacts.html page
Contacts.html page lists all the contacts
To add a new contact click 'Add Contact' button, this will clear data from input fields (if any). The fill all the input fields and hit "Add" button. The newly created 
cotact should be displayed in the grid above.
To update a contact, hit the edit button for specific row in grid the contact details would be filled in input fields below grid. Modify the contact details and hit
'Update' button to save the modifications. The modified contact will be displayed in grid above.
To delete a contact hit the 'Delete' icon/button for specific row in the grid, this will delete the specific contact and it will be removed from grid.
