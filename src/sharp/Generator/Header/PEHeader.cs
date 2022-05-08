namespace sharp
{
    public class PEHeader
    {
        public static byte[] Build()
        {
            Header header = new Header();
            header.mzHeader = new MZHeader();
            header.dosStub = new DOSStub();
            header.coffHeader = new COFFHeader();
            header.optionalHeader = new OptionalHeader();
            header.dataDirectories = new DataDirectories();
            header.codeSection = new CodeSection();
            header.importTable = new ImportTable();

            return header.ToByteArray();
        }

        struct Header
        {
            public MZHeader mzHeader;
            public DOSStub dosStub;
            public COFFHeader coffHeader;
            public OptionalHeader optionalHeader;
            public DataDirectories dataDirectories;
            public CodeSection codeSection;
            public ImportTable importTable;
        }

        struct MZHeader
        {
            public byte magicM;
            public byte magicZ;
            public ushort bytesInLastPage;
            public ushort pageCount;
            public ushort relocationCount;

            public ushort headerParagraphCount;
            public ushort minimumExtraParagraphCount;
            public ushort maximumExtraParagraphCount;

            public ushort startingSS;
            public ushort startingSP;
            public ushort checksum;
            public ushort startingIP;
            public ushort startingCS;

            public ushort relocationTableOffset;
            public ushort overlayNumber;

            public ushort padding1;
            public ushort padding2;

            public ushort oemId;
            public ushort oemInfo;

            public ushort padding3;
            public ushort padding4;
            public ulong padding5;
            public ulong padding6;

            public uint padding7;
            public uint standardHeaderOffset;
        }

        struct DOSStub
        {
            public unsafe fixed byte message[64];
        }

        struct COFFHeader
        {
            public uint signature;

            public ushort machineType;
            public ushort numberOfSections;
            public uint timeDateStamp;

            public uint pointerToSymbolTable;
            public uint numberOfSymbols;

            public ushort sizeOfOptionalHeader;
            public ushort characteristics;
        }

        struct OptionalHeader
        {
            public ushort magic;
            public byte majorLinkerVersion;
            public byte minorLinkerVersion;

            public uint sizeOfCode;
            public uint sizeOfInitializedData;
            public uint sizeOfUninitializedData;

            public uint addressOfEntryPoint;
            public uint baseOfCode;
            public uint baseOfData;
            public uint imageBase;

            public uint sectionAlignment;
            public uint fileAlignment;

            public ushort majorOperatingSystemVersion;
            public ushort minorOperatingSystemVersion;

            public ushort majorImageVersion;
            public ushort minorImageVersion;

            public ushort majorSubsystemVersion;
            public ushort minorSubsystemVersion;

            public uint win32VersionValue;

            public uint sizeOfImage;
            public uint sizeOfHeaders;
            public uint checkSum;

            public ushort subsystem;
            public ushort characteristics;

            public uint sizeOfStackReserve;
            public uint sizeOfStackCommit;

            public uint sizeOfHeapReserve;
            public uint sizeOfHeapCommit;

            public uint loadFlags;
            public uint numberOfRvaAndSizes;
        }

        struct DataDirectories
        {
            public unsafe fixed uint directories[32];
        }

        struct CodeSection
        {
            public ulong name;
            public uint virtualSize;
            public uint virtualAddress;

            public uint sizeOfRawData;
            public uint pointerToRawData;
            public uint pointerToRelocations;
            public uint pointerToLinenumbers;

            public ushort numberOfRelocations;
            public ushort numberOfLinenumbers;

            public uint characteristics;
        }

        struct ImportTable
        {
            public unsafe fixed ulong importTableBytes[12];
        }
    }
}
