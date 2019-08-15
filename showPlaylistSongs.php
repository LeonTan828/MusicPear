<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $thisPlaylistID = $_POST["playlistname"];

    $playlistshowquery = "SELECT s.songID, s.artist, s.album FROM songs s, playlist p, belongs_to b WHERE p.PID = '" . $thisPlaylistID . "' AND p.PID = b.LID AND b.songID = s.songID;";
    $playlistshow = mysqli_query($con, $playlistshowquery) or die("failed to find playlist");

    if (mysqli_num_rows($playlistshow) == 0)
    {
        echo("No such playlist exist");
        exit();
    }

    echo("0@");

    while($row = mysqli_fetch_assoc($playlistshow))
    {
        echo($row['title'] . '$' . $row['artist'] . '$' . $row['album'] );
    }
    // NOTE figure out how to return the search results
?>