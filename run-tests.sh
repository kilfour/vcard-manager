# Bash/Zsh script (Mac/Linux)
# File: run-tests.sh

#!/bin/bash

MODE="unit"

if [ "$1" == "integration" ]; then
    MODE="integration"
fi

if [ "$MODE" == "unit" ]; then
    FILTER="Category!=Integration"
else
    FILTER="Category=Integration"
fi

echo "Running $MODE tests with filter: $FILTER"
dotnet test --filter "$FILTER"