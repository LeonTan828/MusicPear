<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $thisUser = $_POST["userID"];

    $avatarLoadquery = "SELECT body, head, color FROM avatar, WHERE userID = '" . $thisUser . "';";
    $avatarLoad = mysqli_query($con, $avatarLoadquery) or die("failed to find avatar");

    if (mysqli_num_rows($avatarLoad) == 0)
    {
        echo("No such avatar exist");
        exit();
    }

    echo("0@");

    while($row = mysqli_fetch_assoc($avatarLoad))
    {
        echo($row['body'] . '$' . $row['head'] . '$' . $row['color'] );
    }
    // NOTE figure out how to return the search results
?>