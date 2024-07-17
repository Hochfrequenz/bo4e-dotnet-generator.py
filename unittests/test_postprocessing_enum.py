from pathlib import Path

from bo4egenerator.postprocessing.mwe import parse_enum_file_mwe

repo_root = Path(__file__).parent.parent


def test_post_processing_enum_mwe():
    actual = parse_enum_file_mwe(repo_root / "src" / "dotnet-classes" / "enum" / "Abgabeart.cs")
    assert (
        actual
        == """
    /// <summary>
/// Art der Konzessionsabgabe
/// </summary>
""".strip()
    )
