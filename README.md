# Solution explanation
The code to find the solutions to the challenge is found in the **TestService.cs** file, this service consists of a series of methods:
- public TestResult Test(uint X, uint Y,uint Z, bool applyBadPath = false)
- private Process[] getProcesses(uint X, uint Y, uint Z, bool goodPath)
- private PathEnum getPath(uint X, uint Y, uint Z, bool goodPath)
- private Process[] subtract(uint X, uint Y, uint Z)
- private Process[] add(uint X, uint Y, uint Z)
- private bool validateParams(uint X, uint Y, uint Z)
- private bool isRestable(uint X, uint Y, uint Z)
- private bool isSumable(uint X, uint Y, uint Z)

The main method is called Test and receive the data necessary (X,Y,Z) to calculate the solutions to the challenge. First it is validated that the values ​​provided are valid, this happens in the validateParams method.
The method isRestable and isSumable methods validate which algorithm can be used according to the data provided, 
there are two algorithms subtract and add.

The Subtract algorithm first fills the bucket with the largest capacity and transfers the water to the bucket with the least capacity until Z is reached.

The Add algorithm fills the bucket with the smallest capacity and transfers the water to the bucket with the largest capacity until Z is reached.

The getPath method decides which algorithm is used, whether Subtract or Add, for this it mainly uses the isRestable and isSumable methods.

The getProcesses method returns the result of the Add or Subtract algorithms to the Test method.

If the request comes from the browser, only the best solution for the challenge is calculated, but if the endpoint **/Home/test** is used then the best and worst solution are calculated.

The Json to make the requests must contain X, Y and Z

**POST:** https://localhost:44332/Home/test

**PAYLOAD:**
```json
{
    "X":2,
    "Y":2,
    "Z":2
}
```
**RESPONSE:**
```json
{
    "good": [
        {
            "x": 0,
            "y": 2,
            "explanation": "Fill bucket Y. Solved"
        }
    ],
    "bad": [
        {
            "x": 0,
            "y": 2,
            "explanation": "Fill bucket Y. Solved"
        }
    ]
}
```

# Instructions to run the program
1- Clone the repository https://github.com/siulfe/WaterBucketChallenge2024/tree/master
2- Using Visual Studio use IIS Express to run the program.

The program is MVC .Net Core 2.2 application.

# Test Case
1- 
**Values:**
- X: 5
- Y: 15
- Z: 10
**Response expected**
```json
{
    "good": [
        {
            "x": 0,
            "y": 15,
            "explanation": "Fill bucket Y"
        },
        {
            "x": 5,
            "y": 10,
            "explanation": "Transfer from bucket Y to bucket X. Solved"
        }
    ],
    "bad": [
        {
            "x": 5,
            "y": 0,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 5,
            "explanation": "Transfer from bucket X to bucket Y"
        },
        {
            "x": 5,
            "y": 5,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 10,
            "explanation": "Transfer from bucket X to bucket Y. Solved"
        }
    ]
}
```

2- 
**Values:**
- X: 2
- Y: 2
- Z: 2
**Response expected**
```json
{
    "good": [
        {
            "x": 0,
            "y": 2,
            "explanation": "Fill bucket Y. Solved"
        }
    ],
    "bad": [
        {
            "x": 0,
            "y": 2,
            "explanation": "Fill bucket Y. Solved"
        }
    ]
}
```

3-
**Values**
- X: 8
- Y: 16
- Z: 12

**Response expected**

"No Solution"

4-
**Values**
- X: 4
- Y: 24
- Z: 12

**Response expected**
```json
{
    "good": [
        {
            "x": 4,
            "y": 0,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 4,
            "explanation": "Transfer from bucket X to bucket Y"
        },
        {
            "x": 4,
            "y": 4,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 8,
            "explanation": "Transfer from bucket X to bucket Y"
        },
        {
            "x": 4,
            "y": 8,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 12,
            "explanation": "Transfer from bucket X to bucket Y. Solved"
        }
    ],
    "bad": [
        {
            "x": 4,
            "y": 0,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 4,
            "explanation": "Transfer from bucket X to bucket Y"
        },
        {
            "x": 4,
            "y": 4,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 8,
            "explanation": "Transfer from bucket X to bucket Y"
        },
        {
            "x": 4,
            "y": 8,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 12,
            "explanation": "Transfer from bucket X to bucket Y. Solved"
        }
    ]
}
```

5-
**Values**
- X: 3
- Y: 11
- Z: 5

**Response expected**

"No Solution"

6-
**Values**
- X: 4
- Y: 11
- Z: 3

**Response expected**
```json
{
    "good": [
        {
            "x": 0,
            "y": 11,
            "explanation": "Fill bucket Y"
        },
        {
            "x": 4,
            "y": 7,
            "explanation": "Transfer from bucket Y to bucket X"
        },
        {
            "x": 0,
            "y": 7,
            "explanation": "Empty bucket X"
        },
        {
            "x": 4,
            "y": 3,
            "explanation": "Transfer from bucket Y to bucket X. Solved"
        }
    ],
    "bad": [
        {
            "x": 0,
            "y": 11,
            "explanation": "Fill bucket Y"
        },
        {
            "x": 4,
            "y": 7,
            "explanation": "Transfer from bucket Y to bucket X"
        },
        {
            "x": 0,
            "y": 7,
            "explanation": "Empty bucket X"
        },
        {
            "x": 4,
            "y": 3,
            "explanation": "Transfer from bucket Y to bucket X. Solved"
        }
    ]
}
```

7-
**Values**
- X: 2
- Y: 10
- Z: 4

**Response expected**
```json
{
    "good": [
        {
            "x": 2,
            "y": 0,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 2,
            "explanation": "Transfer from bucket X to bucket Y"
        },
        {
            "x": 2,
            "y": 2,
            "explanation": "Fill bucket X"
        },
        {
            "x": 0,
            "y": 4,
            "explanation": "Transfer from bucket X to bucket Y. Solved"
        }
    ],
    "bad": [
        {
            "x": 0,
            "y": 10,
            "explanation": "Fill bucket Y"
        },
        {
            "x": 2,
            "y": 8,
            "explanation": "Transfer from bucket Y to bucket X"
        },
        {
            "x": 0,
            "y": 8,
            "explanation": "Empty bucket X"
        },
        {
            "x": 2,
            "y": 6,
            "explanation": "Transfer from bucket Y to bucket X"
        },
        {
            "x": 0,
            "y": 6,
            "explanation": "Empty bucket X"
        },
        {
            "x": 2,
            "y": 4,
            "explanation": "Transfer from bucket Y to bucket X. Solved"
        }
    ]
}
```

# Additional information
There are only two endpoints, the one used by the UI and the one used to make POST requests. Both are located in the HomeController.cs file. The operation of the two endpoints is very similar.
The models are found in the Models folder, there is also the folder where the IBucket interface is located.
The most complex model is the Bucket model, it contains the implementation of the IBucket interface with the Fill, Empty and Transfer methods.
There is only one enum which contains the values ​​Subtract and Add. Used in TestService.cs to indicate what type of algorithm is required.

_Thank you for reading all the information and I hope you like the program_
