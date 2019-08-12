<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $searchterm = $_POST["searchterm"];

    $artistsearchquery = "SELECT songID FROM songs WHERE artist = '" . $searchterm . "';";
    $artistsearch = mysqli_query($con, $artistsearchquery) or die("artist search failed");

    if (mysqli_num_rows($artistsearch) == 0)
    {
        echo("No such artist exist");
        exit();
    }

    echo("0 ");

    while($row = mysqli_fetch_assoc($titlesearch))
    {
        echo($row['songID'] );
    }
    // NOTE figure out how to return the search results
?>