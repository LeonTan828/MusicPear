<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $thisUser = $_POST["userID"];

    $libraryshowquery = "SELECT s.songID, s.artist, s.album FROM songs s, my_library l, belongs_to b WHERE l.userID = '" . $thisUser . "' AND l.LID = b.LID AND b.songID = s.songID;";
    $libraryshow = mysqli_query($con, $libraryshowquery) or die("failed to find library");

    if (mysqli_num_rows($libraryshow) == 0)
    {
        echo("No such library exist");
        exit();
    }

    echo("0@");

    while($row = mysqli_fetch_assoc($libraryshow))
    {
        echo($row['title'] . '$' . $row['artist'] . '$' . $row['album'] );
    }
    // NOTE figure out how to return the search results
?>