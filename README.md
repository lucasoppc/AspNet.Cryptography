# NetCore.Cryptography
Lightweight Package to Encript passwords with SHA256 and randomnly generated salt.

How to use?
1. Create an instance of the class Hash.
2. Use the Method HashPasswordWithRandomSalt, which returns a tuple (resulting hash, resulting salt)
3. You should store the resulting hash and salt together
4. If you whant to check the password, use the method HashPasswordAndSalt(string password, string saltAsBase64String) which returns the result hash to compare with the one in the database, if they are the same, the password was the same.
