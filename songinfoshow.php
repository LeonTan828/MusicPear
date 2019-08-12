<?php
    $con = mysqli_connect('localhost', 'root', 'root', 'musicpear');

    // Check to seee if the connection was successful
    if (mysqli_connect_errno())
    {
        echo("connection failed");
        exit();
    }

    $searchterm = $_POST["searchID"];

    $resultsearchquery = "SELECT title, artist, album FROM songs WHERE songID = '" . $searchterm . "';";
    $resultsearch = mysqli_query($con, $resultsearchquery) or die("result search failed");

    if (mysqli_num_rows($resultsearch) == 0)
    {
        echo("Something is horribly wrong");
        exit();
    }

    echo("0 ");

    while($row = mysqli_fetch_assoc($titlesearch))
    {
        echo($row['title']);
        
        //echo($row['title'] . '\$' . $row['artist'] . '\$' . $row['album']);
    }
    // NOTE figure out how to return the search results
?>