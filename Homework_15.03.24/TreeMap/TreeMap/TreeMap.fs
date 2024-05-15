namespace Tree

module TreeMap =
    type 'a Tree =
        | Tree of 'a * 'a Tree * 'a Tree
        | Empty
        
    let rec treeMap tree f =
        match tree with
        | Empty -> Empty
        | Tree (value, left, right) -> Tree (f value, treeMap left f, treeMap right f)  