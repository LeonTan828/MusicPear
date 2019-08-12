<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $searchterm = $_POST["searchterm"];

    $albumsearchquery = "SELECT songID FROM songs WHERE album = '" . $searchterm . "';";
    $albumsearch = mysqli_query($con, $albumsearchquery) or die("album search failed");

    if (mysqli_num_rows($albumsearch) == 0)
    {
        echo("No such album exist");
        exit();
    }

    echo("0");
    // NOTE figure out how to return the search results
?>