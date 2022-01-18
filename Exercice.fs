
// Exercice 1.A
let five = 5
let seven = 7
let cube (x: int) =  x*x*x

printfn "x: %i" (cube(five))
printfn "x: %i" (cube(seven))

// Exercice 1.B
// .1
let interestRate (balance: decimal): single =
    match balance with 
    |   balance when balance < 0m -> 0.03213f 
    |   balance when 0m < balance && balance < 1000m -> 0.005f
    |   balance when 1000m <= balance && balance < 5000m -> 0.01621f
    |   balance when balance >= 5000m -> 0.02475f
    |   _-> 0f

interestRate (200.75m) |> printfn "%f"
//.2
let interest (balance: decimal): decimal =
    System.Convert.ToDecimal (interestRate (200.75m)) * balance /100m

interest (200.75m) |> printfn "%f"

//.3

let annualBalanceUpdate (balance: decimal): decimal =
    balance + interest(200.75m)

annualBalanceUpdate (200.75m) |> printfn "%f"

//.4

let amountToDonate (balance: decimal)(taxFreePercentage: float): int =
    let taxFree = taxFreePercentage/float(100)
    int (balance * decimal(taxFree))*2

let balance = 550.5m
let taxFreePercentage = 2.5

//amountToDonate () () |> printfn "%i"

// fin exercice 1

//Exercice 2

//A.

//1.
let message(newspaperline : string): string = 
    let cut = newspaperline.Split[|':'|]
    cut[1].Trim(' ')

message "[WARNING] : Operation Invalide" |> printf "%s"
//2.
let logLevel(newspaperline : string):string = 
    let cut = newspaperline.Split[|':'|]
    cut[0].Trim('[',']',' ').ToLower()

logLevel "[ERREUR] : Operation Invalide" |> printf "%s"

//3.
let reformat(newspaperline : string):string =
    message(newspaperline) + " (" + logLevel(newspaperline) + ")"

reformat "[INFO] : Operation terminée" |> printf "%s"

//B.

let talkingToBob(sentence : string):string =
    match sentence with
    | sentence when sentence.Contains("Comment ça va ?") -> "Bien sûr"
    | sentence when (sentence = sentence.ToUpper()) -> "Whoa, calme-toi !"  
    | sentence when (sentence = sentence.ToUpper() && sentence.Contains('?')) -> "Calme-toi, je sais ce que je fais"    
    | sentence when (sentence = "") -> "Très bien. Sois comme ça"
    | _ -> "Peu importe"
    
talkingToBob "Comment ça va ?" |> printf "%s"

// III Les structures de données

// A Les records

// 1.

type Coach = {Name : string; FormerPlayer : bool}
type Stats = {Wins : int; Pertes : int}
type Team = {Name : string; Coach : Coach; Stats : Stats}

// 2.

let createCoach(name: string) (former: bool): Coach =
    {Name = name; FormerPlayer = former}

let IndianaCoach = createCoach "Larry Bird" true 

// 3.

let createStats(victoire: int) (pertes: int): Stats =
    {Wins = victoire; Pertes = pertes}

let IndianaStats = createStats 58 24

// 4.

let createTeam(name : string) (coach : Coach)(stats : Stats): Team =
    {Name = name;Coach = coach; Stats = stats}

let IndianaTeam = createTeam "Indiana Pacers" IndianaCoach IndianaStats

// 5.

let replaceCoach(team : Team)(coach : Coach): Team=
    let Team = {team with Coach = coach}
    Team 

let newIndianaCoach = createCoach "Isiah Thomas" true
replaceCoach IndianaTeam newIndianaCoach

// 6.

let isSameTeam(team1 : Team)(team2:Team):bool =
    team1 = team2

    // Indiana pacers
let pacersCoach = createCoach "Larry Bird" true
let pacersStats = createStats 58 24
let pacersTeam = createTeam "Indiana Pacers" pacersCoach pacersStats

    // Los Angeles Lakers

let lakersCoach = createCoach "Del Harris" false
let lakersStats = createStats 61 21
let lakersTeam = createTeam "LA Lakers" lakersCoach lakersStats

isSameTeam IndianaTeam pacersTeam |> printfn "%b"
isSameTeam pacersTeam lakersTeam |> printfn "%b"
// 7.

let supportTeam(team : Team)=
    match team with
    | team when (team.Coach.Name = "Gregg Popovich") -> true
    | team when (team.Coach.FormerPlayer = true) -> true
    | team when (team.Name = "Chicago Bulls") -> true
    | team when (team.Stats.Wins >= 60) -> true
    | team when (team.Stats.Wins < team.Stats.Pertes) -> true
    |_ -> false

let spursCoach = createCoach "Greg Popovich" false
let spursStats = createStats 56 26
let spursTeam = createTeam "San Antonio Spurs" spursCoach spursStats

supportTeam spursTeam |> printfn "%b"

// B Les enums

// 1.

type Approbation =
    | Non 
    | Oui 
    | Bof
    
// 2.

type Cuisines =
    | Coreen 
    | Turc 

// 3.

type Genre =
    | Crime 
    | Horreur 
    | Romance 
    | Thriller 

 // 4.

type Activité = 
    | BoardGame
    | Chill
    | Film of Genre
    | Restaurant of Cuisines
    | Walk  of int
 
 // 5.

let rateActivity(activity : Activité)=
    match activity with
    | Film f when f = Genre.Romance -> Oui
    | Restaurant r when r = Cuisines.Coreen -> Oui
    | Restaurant r when r = Cuisines.Turc -> Bof
    | Walk w when w < 3 -> Oui
    | Walk w when w < 5 -> Bof
    |  _ -> Non

rateActivity (Restaurant Turc) |> printfn "%O"