<?php
    $con = mysqli_connect('localhost:3307', 'root', 'root', 'musicpear');

    //check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo "connection failed";
        exit()
    }

    $name = $_POST["name"];
    $username = $_POST["username"];
    $password = $_POST["password"];

    //check if username is already taken
    $usernamecheckquery = "SELECT userID FROM user WHERE userID='" . $username . "';";

    $namecheck = mysqli_query($con, $usernamecheckquery) or die("userID check failed");

    if (mysqli_num_rows($usernamecheckquery) > 0)
    {
        echo "username already exists";
        exit();
    }

    //add user to the table
    $insertuserquery = "INSERT INTO user (username, password, userID) VALUES ('" . $username ."', '" . $password . "', '" . $name . "');";
    mysqli_query($con, $insertuserquery) or die("Insert user failed");

    echo("0");
 ?>
