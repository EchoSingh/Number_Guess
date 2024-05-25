open System

// Function to generate a random number between min and max (inclusive)
let generateRandomNumber min max =
    let rnd = Random()
    rnd.Next(min, max + 1)

// Main game loop
let rec playGame (targetNumber: int) (attemptsLeft: int) =
    printfn "Guess the number (between 1 and 100):"
    match Console.ReadLine() with
    | input ->
        match Int32.TryParse input with
        | true, guess ->
            if guess = targetNumber then
                printfn "Congratulations! You guessed the correct number."
            elif guess < targetNumber then
                printfn "Too low. Try again."
                if attemptsLeft > 1 then
                    playGame targetNumber (attemptsLeft - 1)
                else
                    printfn "Out of attempts. The correct number was %d." targetNumber
            else
                printfn "Too high. Try again."
                if attemptsLeft > 1 then
                    playGame targetNumber (attemptsLeft - 1)
                else
                    printfn "Out of attempts. The correct number was %d." targetNumber
        | _ ->
            printfn "Invalid input. Please enter a valid number."
            playGame targetNumber attemptsLeft

// Start the game
let main () =
    printfn "Welcome to the Number Guessing Game!"
    let targetNumber = generateRandomNumber 1 100
    let attempts = 5 //adjust number of attempt
    playGame targetNumber attempts

main ()
