Documentation for Mini API Project (InterestAPI)
------------------------------------------------------------------------------------
This API stores users, their interests and eventual links to respective interest.
Below, you can see how I tested the different calls of the API.
I have also added diagrams for the API.

------------------------------------------------------------------------------------

GET calls

1)	http://localhost:XXXX/user
Returns all users (with ID, first name and last name).

2)	http://localhost:XXXX/interest/{userId}
Returns all registered interests of the specified userId (with title and description).

3)	http://localhost:XXXX/interest-link/{userId}
Returns all the uploaded (interest) links connected to the specified userId.

------------------------------------------------------------------------------------

POST calls

4)	http://localhost:XXXX/interest/create
By typing in title of new interest and a description, and then posting it, a new interest will be created. Code 201 will tell you if interest is created successfully.

5)	http://localhost:XXXX/user/{userId}/interest/{interestId}
Returns code 201 if new interest (with interestId) is successfully connected to a userId.

6)	http://localhost:XXXX/user/{userId}/interest/{interestId}/interest-link
By adding a link in the post, code 201 will say if the new link is added.

------------------------------------------------------------------------------------
 
![image](https://github.com/Quynh-Truong/MiniProjectAPI/assets/146139597/ccf6e5b3-95d7-4f38-b0a1-9b3c875d79ce)

![image](https://github.com/Quynh-Truong/MiniProjectAPI/assets/146139597/e61d488e-98d2-4d66-9b71-82db05aef023)


