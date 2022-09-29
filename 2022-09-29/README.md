# Wiederholungsbeispiel Fuhrpark

##Klassendiagramme 
~~~plantuml
@startuml
class Vehicle{
- licensePlate : string 
- model : string
- totalDist : string
- fuellLevel : double
- available : bool
- location : string 

+ LicensePlate {set;get;}: string 
+ Model {get;} : string
+ TotalDist {set;get;} : string
+ FuellLevel {set,get;} : double
+ Available {set,get;} : bool
+ Location {set;get;} : string 

+ Vehicle(lp,mod, totDist, fuell, avail,loc)

+ ToString() : string 
+ Serialize() : string
+ {static} Parse(data : string) : Vehicle
}

@enduml
~~~
