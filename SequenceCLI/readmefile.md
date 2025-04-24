Notes
This CLI app reuses core services originally developed for the MyWinApp Windows application. The same logic and algorithms were imported and called here, providing consistent results between the GUI app and the CLI version.
# LongestConsecutiveSequenceCLI

This CLI application computes the longest consecutive sequence in an integer list.

---

## Usage

Run the app with:

```bash
dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --input "100,4,200,1,3,2" --solution 1
Test Cases
Normal cases
bash
Copier
Modifier
dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --input "100,4,200,1,3,2" --solution 1
# Output: Solution 1 result: 4

dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --input "100,4,200,1,3,2" --solution 2
# Output: Solution 2 result: 4

dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --test
# Runs unit tests outputting pass/fail
Error cases
bash
Copier
Modifier
dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --solution 1
# Output: Error: No input specified.

dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --input "1,2,three"
# Output: Error processing input: Input string was not in a correct format.

dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --input "1,2,3" --solution 5
# Output: Error: --solution must be 1 or 2.

dotnet ./SequenceCLI/bin/Debug/net8.0-windows/SequenceCLI.dll --unknown
# Output: Unknown argument: --unknown
# Usage: (help printed)