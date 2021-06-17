using System.Threading.Tasks; 
using System.Windows; 
using System.Windows.Controls; 
using System.Windows.Shapes; 
using Xunit;
using StreetRacing.VisualElements; 

namespace Test.StreetRacing.VisualElements
{
    /// <summary>
    /// Class for testing WpfGeometry 
    /// </summary>
    public class WpfGeometryTest
    {
        #region Rotation of a point 
        [Fact]
        public async Task RotatePointRotationMatrix_Positive90Deg_PointIn90DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = 1.0; 
                double radians = WpfGeometry.DegreesToRadians(90); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 

                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }
        
        [Fact]
        public async Task RotatePointRotationMatrix_Negative90Deg_PointIn270DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = -1.0; 
                double radians = WpfGeometry.DegreesToRadians(-90); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointRotationMatrix_Positive180Deg_PointIn180DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = -1.0; 
                double yPointAfterRotation = 0.0; 
                double radians = WpfGeometry.DegreesToRadians(180); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointRotationMatrix_Negative180Deg_PointIn180DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = -1.0; 
                double yPointAfterRotation = 0.0; 
                double radians = WpfGeometry.DegreesToRadians(-180); 
                
                //When
                WpfGeometry.RotatePoint(ref xPoint, ref yPoint, radians); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        [Fact]
        public async Task RotatePointDistanceToCenter_Positive90Deg_PointIn90DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance = 1.0;  
                double radians = WpfGeometry.DegreesToRadians(90);
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = 1.0; 
                
                //When
                WpfGeometry.RotatePoint(distance, radians, out xPoint, out yPoint); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }

        
        [Fact]
        public async Task RotatePointDistanceToCenter_Negative90Deg_PointIn270DegOnUnitCircle()
        {
            await ThreadHelper.StartSTATask(() =>
            {
                //Given
                double distance = 1.0;  
                double radians = WpfGeometry.DegreesToRadians(90);
                double xPoint = 1.0; 
                double yPoint = 0.0; 
                double xPointAfterRotation = 0.0; 
                double yPointAfterRotation = 1.0; 
                
                //When
                WpfGeometry.RotatePoint(distance, radians, out xPoint, out yPoint); 
                
                //Then
                Assert.Equal(xPointAfterRotation, xPoint, 5); 
                Assert.Equal(yPointAfterRotation, yPoint, 5); 
            });
        }
        #endregion  // Rotation of a point 
    }
}