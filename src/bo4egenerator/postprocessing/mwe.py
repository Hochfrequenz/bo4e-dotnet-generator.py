from pathlib import Path

import tree_sitter_c_sharp as tscsharp
from tree_sitter import Language, Node, Parser

PY_LANGUAGE = Language(tscsharp.language())


def parse_enum_file_mwe(path: Path) -> str:
    """parses the file, returns the first class/enum docstring"""
    if not path.suffix == ".cs":
        raise ValueError("file must be a .cs file")
    with open(path, "r", encoding="utf-8") as cs_file:
        original_cs_code = cs_file.read()
    parser = Parser(PY_LANGUAGE)
    tree = parser.parse(bytes(original_cs_code, "utf-8"))
    cursor = tree.walk()
    # now check str(tree.root_node); it's e.g. like this:
    """
    (compilation_unit # <-- root node
  (comment) # <-- first child
  (comment) # <-- sibling of first child (1)
  (comment) # <-- sibling of second child (2)
  (comment) # ... (3)
  (comment) # ... (4)
  (comment) # ... (5)
  (comment) # ... (6)
  (namespace_declaration # (7) th sibling
    name: (identifier)
    body: (declaration_list
      (using_directive (identifier))
      (using_directive
        (qualified_name
          qualifier: (qualified_name qualifier: (identifier) name: (identifier))
          name: (identifier)))
      (using_directive (qualified_name qualifier: (identifier) name: (identifier)))
      (using_directive (qualified_name qualifier: (identifier) name: (identifier)))
      (using_directive
        (qualified_name
          qualifier: (qualified_name qualifier: (identifier) name: (identifier))
          name: (identifier)))
      (comment)
      (comment)
      (comment)
      (enum_declaration
        (modifier)
        name: (identifier)
        body: (enum_member_declaration_list
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))
          (enum_member_declaration name: (identifier))))
      (class_declaration
    """
    cursor.goto_first_child()
    assert cursor.node.type == "comment"
    while cursor.goto_next_sibling():
        if cursor.node.type == "namespace_declaration":
            break
    cursor.goto_first_child()  # inside the namespace_declaration
    while cursor.goto_next_sibling():
        if cursor.node.type == "body":
            break
    cursor.goto_first_child()  # inside the body
    previous_comments: list[str] = []
    while cursor.goto_next_sibling():
        if cursor.node.type == "comment":
            previous_comments.append(cursor.node.text.decode("utf-8"))
        if cursor.node.type == "enum_declaration":
            docstring = "\n".join(previous_comments)
            return docstring
    raise ValueError("No docstring found")
