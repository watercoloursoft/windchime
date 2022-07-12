using UnityEngine;

namespace Windchime.Runtime
{
    public static class Extensions
    {
        #region Camera

        public static Tween<float> TweenAspect(this Camera camera, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.aspect, value => camera.aspect = value, to, info);
            return tween;
        }

        public static Tween<Color> TweenColor(this Camera camera, Color to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.backgroundColor, value => camera.backgroundColor = value, to,
                info);
            return tween;
        }

        public static Tween<float> TweenFarClipPlane(this Camera camera, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.farClipPlane, value => camera.farClipPlane = value, to, info);
            return tween;
        }

        public static Tween<float> TweenFieldOfView(this Camera camera, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.fieldOfView, value => camera.fieldOfView = value, to, info);
            return tween;
        }

        public static Tween<float> TweenNearClipPlane(this Camera camera, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.nearClipPlane, value => camera.nearClipPlane = value, to,
                info);
            return tween;
        }

        public static Tween<float> TweenOrthographicSize(this Camera camera, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.orthographicSize, value => camera.orthographicSize = value, to,
                info);
            return tween;
        }

        public static Tween<Rect> TweenPixelRect(this Camera camera, Rect to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.pixelRect, value => camera.pixelRect = value, to, info);
            return tween;
        }

        public static Tween<Rect> TweenRect(this Camera camera, Rect to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => camera.rect, value => camera.rect = value, to, info);
            return tween;
        }

        #endregion

        #region Light

        public static Tween<Color> TweenColor(this Light light, Color to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => light.color, value => light.color = value, to, info);
            return tween;
        }

        public static Tween<float> TweenIntensity(this Light light, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => light.intensity, value => light.intensity = value, to, info);
            return tween;
        }

        public static Tween<float> TweenShadowStrength(this Light light, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => light.shadowStrength, value => light.shadowStrength = value, to,
                info);
            return tween;
        }

        #endregion

        #region LineRenderer

        public static Tween<Gradient> TweenColorGradient(this LineRenderer renderer, Gradient from, Gradient to,
            TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => from, value => renderer.colorGradient = value, to, info);
            return tween;
        }

        #endregion

        #region Material

        public static Tween<Color> TweenColor(this Material material, Color to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.color, value => material.color = value, to, info);
            return tween;
        }

        public static Tween<Color> TweenColor(this Material material, string property, Color to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetColor(property),
                value => material.SetColor(property, value), to, info);
            return tween;
        }

        public static Tween<Color> TweenColor(this Material material, int propertyId, Color to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetColor(propertyId),
                value => material.SetColor(propertyId, value), to, info);
            return tween;
        }

        public static Tween<Color> TweenFade(this Material material, float to, TweenInfo info)
        {
            var tween = TweenScheduler.PlayAlpha(() => material.color, value => material.color = value, to, info);
            return tween;
        }

        public static Tween<Color> TweenFade(this Material material, string property, float to, TweenInfo info)
        {
            var tween = TweenScheduler.PlayAlpha(() => material.GetColor(property),
                value => material.SetColor(property, value), to, info);
            return tween;
        }

        public static Tween<Color> TweenFade(this Material material, int propertyId, float to, TweenInfo info)
        {
            var tween = TweenScheduler.PlayAlpha(() => material.GetColor(propertyId),
                value => material.SetColor(propertyId, value), to, info);
            return tween;
        }

        public static Tween<float> TweenFloat(this Material material, string property, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetFloat(property),
                value => material.SetFloat(property, value), to, info);
            return tween;
        }

        public static Tween<float> TweenFloat(this Material material, int propertyId, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetFloat(propertyId),
                value => material.SetFloat(propertyId, value), to, info);
            return tween;
        }

        public static Tween<Vector2> TweenOffset(this Material material, Vector2 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.mainTextureOffset,
                value => material.mainTextureOffset = value, to, info);
            return tween;
        }

        public static Tween<Vector2> TweenOffset(this Material material, string property, Vector2 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetTextureOffset(property),
                value => material.SetTextureOffset(property, value), to, info);
            return tween;
        }

        public static Tween<Vector2> TweenOffset(this Material material, int propertyId, Vector2 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetTextureOffset(propertyId),
                value => material.SetTextureOffset(propertyId, value), to, info);
            return tween;
        }

        public static Tween<Vector2> TweenTiling(this Material material, Vector2 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.mainTextureScale, value => material.mainTextureScale = value,
                to, info);
            return tween;
        }

        public static Tween<Vector2> TweenTiling(this Material material, string property, Vector2 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetTextureScale(property),
                value => material.SetTextureScale(property, value), to, info);
            return tween;
        }

        public static Tween<Vector2> TweenTiling(this Material material, int propertyId, Vector2 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetTextureScale(propertyId),
                value => material.SetTextureScale(propertyId, value), to, info);
            return tween;
        }

        public static Tween<Vector4> TweenVector(this Material material, string property, Vector4 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetVector(property),
                value => material.SetVector(property, value), to, info);
            return tween;
        }

        public static Tween<Vector4> TweenVector(this Material material, int propertyId, Vector4 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => material.GetVector(propertyId),
                value => material.SetVector(propertyId, value), to, info);
            return tween;
        }

        #endregion

        #region TrailRenderer

        public static Tween<Vector2> TweenResize(this TrailRenderer renderer, Vector2 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => new Vector2(renderer.startWidth, renderer.endWidth), value =>
            {
                renderer.startWidth = value.x;
                renderer.endWidth = value.y;
            }, to, info);
            return tween;
        }

        public static Tween<float> TweenTime(this TrailRenderer renderer, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => renderer.time, value => renderer.time = value, to, info);
            return tween;
        }

        #endregion

        #region Transform

        public static Tween<Vector3> TweenPosition(this Transform transform, Vector3 to, TweenInfo info,
            bool snapping = false)
        {
            var tween = TweenScheduler.Play(() => transform.position, value => transform.position = snapping
                ? new Vector3(Mathf.Round(value.x), Mathf.Round(value.y), Mathf.Round(value.z))
                : value, to, info);
            return tween;
        }

        public static Tween<Vector3> TweenLocalPosition(this Transform transform, Vector3 to, TweenInfo info,
            bool snapping = false)
        {
            var tween = TweenScheduler.Play(() => transform.localPosition, value => transform.localPosition = snapping
                ? new Vector3(Mathf.Round(value.x), Mathf.Round(value.y), Mathf.Round(value.z))
                : value, to, info);
            return tween;
        }

        public static Tween<Quaternion> TweenRotation(this Transform transform, Vector3 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => transform.rotation, value => transform.rotation = value,
                Quaternion.Euler(to), info);
            return tween;
        }

        public static Tween<Quaternion> TweenRotationQuaternion(this Transform transform, Quaternion to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => transform.rotation, value => transform.rotation = value, to, info);
            return tween;
        }

        public static Tween<Quaternion> TweenLocalRotation(this Transform transform, Vector3 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => transform.localRotation, value => transform.localRotation = value,
                Quaternion.Euler(to), info);
            return tween;
        }

        public static Tween<Quaternion> TweenLocalRotationQuaternion(this Transform transform, Quaternion to,
            TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => transform.localRotation, value => transform.localRotation = value, to,
                info);
            return tween;
        }

        public static Tween<Vector3> TweenScale(this Transform transform, Vector3 to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => transform.localScale, value => transform.localScale = value, to,
                info);
            return tween;
        }

        public static Tween<Vector3> TweenScale(this Transform transform, float to, TweenInfo info)
        {
            var tween = TweenScheduler.Play(() => transform.localScale, value => transform.localScale = value,
                new Vector3(to, to, to), info);
            return tween;
        }

        #endregion
    }
}