<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    //check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo "connection failed";
        exit();
    }

    $username = $_POST["username"];
    $password = $_POST["password"];

    $usernamecheckquery = "SELECT userID, password FROM user WHERE userID='" . $username . "';";

    $namecheck = mysqli_query($con, $usernamecheckquery) or die("userID check failed");
    if (mysqli_num_rows($namecheck) != 1)
    {
        echo "either no user with name exists, or more than one";
    }

    //verify that the password is correct
    $existinginfo = mysqli_fetch_assoc($namecheck);
    $passwd = $existinginfo["password"];

    if ($password != $passwd) //if password is incorrect
    {
        echo "incorrect password";
        exit();
    }

    echo "0";
 ?>
