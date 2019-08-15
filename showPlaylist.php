<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $thisUser = $_POST["userID"];

    $userplaylistquery = "SELECT pname, PID FROM playlist p, WHERE p.userID = '" . $thisUser . "';";
    $userplaylist = mysqli_query($con, $userplaylistquery) or die("failed to find playlist");

    if (mysqli_num_rows($userplaylist) == 0)
    {
        echo("No such playlist exist");
        exit();
    }

    echo("0@");

    while($row = mysqli_fetch_assoc($userplaylist))
    {
        echo($row['pname'] . '$' . $row['PID'] );
    }
    // NOTE figure out how to return the search results
?>