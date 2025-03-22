func countConsistentStrings(allowed string, words []string) int {
    ls := make([]bool, 26)
    for _, char := range allowed {
        ls[char-'a'] = true
    }

    c := 0
    for _, word := range words {
        w := true
        for _, char := range word {
            if !ls[char-'a'] {
                w = false
                break
            }
        }
        if w {
            c++
        }
    }
    return c
}
