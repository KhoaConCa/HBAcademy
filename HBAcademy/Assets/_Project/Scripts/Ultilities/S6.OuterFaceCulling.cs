//using System.Runtime.CompilerServices;
//using YNL.Vozel.Mathematics;

//namespace YNL.Vozel.Rendering
//{
//    public partial struct ProceduralWorldGenerationJob
//    {
//        public void OuterFaceCulling(int i)
//        {
//            var sectionRange = Collection.ChunkSections[i];
//            var chunkOffset = i * MaskBound.MaskChunk * 6;

//            for (byte f = 0; f < 6; f++)
//            {
//                var faceOffset = f * MaskBound.MaskChunk;

//                for (byte s = 0; s < ChunkBound.Column; s++)
//                {
//                    if (s < sectionRange.Start || s > sectionRange.End) continue;

//                    var sectionOffset = s * MaskBound.MaskAmount;

//                    for (byte m = 0; m < MaskBound.MaskAmount; m++)
//                    {
//                        var maskIndex = chunkOffset + faceOffset + sectionOffset + m;

//                        if (f == 0)
//                        {
//                            var edgeMask = Collection.OuterMask.EdgeMasks[i * 2048 + f * ChunkBound.TotalHeight + s * 16 + m / 4];
//                            Collection.FinalCullings[maskIndex] = Collection.InnerCullings[maskIndex] & ~Math.HighBits4To64(edgeMask, m % 4 * 4);
//                        }
//                        else if (f == 1)
//                        {
//                            var edgeMask = Collection.OuterMask.EdgeMasks[i * 2048 + f * ChunkBound.TotalHeight + s * 16 + m / 4];
//                            Collection.FinalCullings[maskIndex] = Collection.InnerCullings[maskIndex] & ~Math.LowBits4To64(edgeMask, m % 4 * 4);
//                        }
//                        else if (f == 2)
//                        {
//                            var edgeMask = Collection.OuterMask.EdgeMasks[i * 2048 + f * ChunkBound.TotalHeight + s * 16 + m / 4];
//                            Collection.FinalCullings[maskIndex] = Collection.InnerCullings[maskIndex] & ~Math.HighBits4To64(edgeMask, m % 4 * 4);
//                        }
//                        else if (f == 3)
//                        {
//                            var edgeMask = Collection.OuterMask.EdgeMasks[i * 2048 + f * ChunkBound.TotalHeight + s * 16 + m / 4];
//                            Collection.FinalCullings[maskIndex] = Collection.InnerCullings[maskIndex] & ~Math.LowBits4To64(edgeMask, m % 4 * 4);
//                        }
//                        else if (f == 4)
//                        {
//                            ApplyVerticalMask(chunkOffset + faceOffset + sectionOffset, (i * 6 + 5) * MaskBound.MaskChunk, true, s, m);
//                        }
//                        else if (f == 5)
//                        {
//                            ApplyVerticalMask(chunkOffset + faceOffset + sectionOffset, (i * 6 + 4) * MaskBound.MaskChunk, false, s, m);
//                        }
//                    }
//                }
//            }
//        }

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        private ulong CullLeft(ulong mask, ulong culler) => mask & ~((culler & MaskBound.RightEdgeMask) << (ChunkBound.Dimension - 1));

//        [MethodImpl(MethodImplOptions.AggressiveInlining)]
//        private ulong CullRight(ulong mask, ulong culler) => mask & ~((culler & MaskBound.LeftEdgeMask) >> (ChunkBound.Dimension - 1));

//        private void ApplyVerticalMask(int baseOffset, int targetBase, bool isLeftCulled, byte s, byte m)
//        {
//            var targetSection = isLeftCulled ? s + 1 : s - 1;

//            var baseMask = Collection.InnerCullings[baseOffset + m];
//            var targetMask = Collection.InnerCullings[targetBase + targetSection * MaskBound.MaskAmount + m];

//            Collection.FinalCullings[baseOffset + m] = isLeftCulled ?
//                CullLeft(baseMask, targetMask) :
//                CullRight(baseMask, targetMask);
//        }
//    }
//}